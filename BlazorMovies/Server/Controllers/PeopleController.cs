using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMovies.DAL.Data;
using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorMovies.Server.Controllers {
	[ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class PeopleController : ControllerBase {
        private readonly IUserData _repo;
        private readonly IConfiguration _config;
        private readonly IFileStorageService _fileStorageService;

        public PeopleController(IUserData userData, IConfiguration configuration, IFileStorageService fileStorageService) {
            _repo = userData;
            _config = configuration;
            _fileStorageService = fileStorageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get([FromQuery] PageNumberSizeDTO pageNumberSizeDTO) {
            var queryable = (await _repo.GetPeople()).AsQueryable();
            HttpContext.InsertPageTotalInHeader(queryable, pageNumberSizeDTO.PageSize);

            return queryable.Paginate(pageNumberSizeDTO).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id) {
            var person = await _repo.GetPersonById(id);
            if (person == null) { return NotFound(); }

            return person;
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<List<Person>>> FilterByName(string searchText) {
            if (string.IsNullOrWhiteSpace(searchText)) { return new List<Person>(); }

            var limit = Convert.ToInt32(_config.GetSection("AppSettings:Limit").Value);

            return await _repo.SearchPeople(limit, searchText);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Person person) {
            if (!string.IsNullOrWhiteSpace(person.Picture)) {
                var personPicture = Convert.FromBase64String(person.Picture);
                person.Picture = await _fileStorageService.SaveFile(personPicture, "jpg", "people");
            }

            return await _repo.CreatePerson(person);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Person person) {
            var personDB = await _repo.GetPersonById(person.Id);
            if (personDB == null) { return NotFound(); }

            if (!string.IsNullOrWhiteSpace(person.Picture)) {
                var personPicture = Convert.FromBase64String(person.Picture);
                personDB.Picture = await _fileStorageService.EditFile(personPicture, "jpg", "people", personDB.Picture);
            }

            await _repo.UpdatePerson(person);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            var personDB = await _repo.GetPersonById(id);
            if (personDB == null) { return NotFound(); }

            await _repo.DeletePerson(id);

            return NoContent();
        }
    }
}