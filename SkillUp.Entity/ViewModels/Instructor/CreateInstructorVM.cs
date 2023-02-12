using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.Entity.ViewModels
{
    public class CreateInstructorVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Description { get; set; }
        public string? FacebookURL { get; set; }
        public string? TwitterURL { get; set; }
        public string? InstagramUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string StripeKey { get; set; }


        public IFormFile Image { get; set; }
        public IFormFile Preview { get; set; }

    }
}
