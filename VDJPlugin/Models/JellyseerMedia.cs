using System;

namespace VDJPlugin.Models
{
    public class JellyseerMedia
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string MediaType { get; set; }  // "movie" ou "tv"
        public int? TmdbId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Status { get; set; }
    }
} 