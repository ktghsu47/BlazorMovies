﻿using System;

namespace BlazorMovies.Shared.DTOs {
	public class TokenDTO {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}