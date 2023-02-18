using Microsoft.AspNetCore.Identity;
using SkillUp.Core.Entities;
using SkillUp.Entity.Entities.Relations.InstructorExtraProperities;
using SkillUp.Entity.Entities.Relations.ManyToMany;
using SkillUp.Entity.Entities.Reviews;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.Entity.Entities
{
    public class Instructor:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string PreviewVideoUrl { get; set; }
        public string? FaceBookUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public byte Experince { get; set; }


        public ICollection<InstructorProfession> InstructorProfessions { get; set; }
        public ICollection<AppUserInstructor> AppUserInstructors { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<CourseReview> CourseReviews { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }


    }
}
