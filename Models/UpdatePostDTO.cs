﻿namespace BugSpotterBE.Models
{
    public class UpdatePostDTO
    {
        public int CollectionId { get; set; }
        public string Image {  get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public bool Favorite { get; set; }
    }
}
