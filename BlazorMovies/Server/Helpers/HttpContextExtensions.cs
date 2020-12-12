using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace BlazorMovies.Server.Helpers {
	public static class HttpContextExtensions {
        public static void InsertPageTotalInHeader<T>(this HttpContext httpContext, IQueryable<T> queryable, int pageSize) {
            if (httpContext == null) { throw new ArgumentNullException(nameof(httpContext)); }

            double totalCount = Convert.ToInt32(queryable.Count());
            double pageTotal = Math.Ceiling(totalCount / pageSize);
            httpContext.Response.Headers.Add("pageTotal", pageTotal.ToString());
        }
    }
}