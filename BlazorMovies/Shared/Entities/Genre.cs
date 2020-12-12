﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorMovies.Shared.Entities {
	public class Genre {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}