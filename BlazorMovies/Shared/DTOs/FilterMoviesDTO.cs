namespace BlazorMovies.Shared.DTOs {
	public class FilterMoviesDTO {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Title { get; set; }
        public int GenreId { get; set; }
        public bool InTheaters { get; set; }
        public bool UpcomingReleases { get; set; }
        public PageNumberSizeDTO PageNumberSizeDTO {
            get { return new PageNumberSizeDTO() { PageNumber = PageNumber, PageSize = PageSize }; }
        }
    }
}