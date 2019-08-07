using System;
using System.Collections.Generic;

namespace InfluencerApp.API.Models
{
    public class User
    {
        public int Id {  get; set; }
        public string Username {  get; set; }
        public byte[] PasswordHash {  get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string InfluencerOrBrand { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Genres { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public string InstagramProfileLink { get; set; }
        public string YoutubeChannelLink { get; set; }
        public string FacebookProfileLink { get; set; }
        public string TwitterProfileLInk { get; set; }
        public ICollection<Like> Likers { get; set; }
        public ICollection<Like> Likees { get; set; }
        
    }
}