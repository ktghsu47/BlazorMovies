﻿namespace BlazorMovies.Shared.Entities {
	public class MovieActor {
        public int PersonId { get; set; }
        public int MovieId { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }

        public Person Person { get; set; }
        public Movie Movie { get; set; }
    }
}