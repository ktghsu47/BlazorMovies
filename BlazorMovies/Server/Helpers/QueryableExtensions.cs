using System.Linq;
using BlazorMovies.Shared.DTOs;

namespace BlazorMovies.Server.Helpers {
	public static class QueryableExtensions {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PageNumberSizeDTO pageNumberSizeDTO) {
            return queryable
                .Skip((pageNumberSizeDTO.PageNumber - 1) * pageNumberSizeDTO.PageSize)
                .Take(pageNumberSizeDTO.PageSize);
        }
    }
}