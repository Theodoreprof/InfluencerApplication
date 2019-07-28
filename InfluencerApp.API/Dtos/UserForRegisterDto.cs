using System.ComponentModel.DataAnnotations;

namespace InfluencerApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username {get; set;}

        [Required]
        [StringLength(24, MinimumLength = 4, ErrorMessage="You must specify password between 4 and 24 characters")]
        public string password {get; set;}
    }
}