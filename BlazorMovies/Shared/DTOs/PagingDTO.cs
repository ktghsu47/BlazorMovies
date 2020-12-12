namespace BlazorMovies.Shared.DTOs {
	public class PagingDTO<T> {
        public T Response { get; set; }
        public int PageTotal { get; set; }
    }
}