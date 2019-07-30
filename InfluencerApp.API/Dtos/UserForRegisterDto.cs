using System;
using System.ComponentModel.DataAnnotations;

namespace InfluencerApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string InfluencerOrBrand { get; set; }

        [Required]
        public string Username {get; set;}

        [Required]
        [StringLength(24, MinimumLength = 4, ErrorMessage="You must specify password between 4 and 24 characters")]
        public string password {get; set;}
        [Required]
        public string KnownAs { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Genres { get; set; }
        [Required]
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}