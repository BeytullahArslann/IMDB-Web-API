using System;
using System.Collections.Generic;

namespace IMDB_Web_API.Models
{
    public partial class MovieList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public string? MoviePosterPath { get; set; }
        public int ListId { get; set; }
        public bool IsDeleted { get; set; }
        public bool Type { get; set; }

    }
}
