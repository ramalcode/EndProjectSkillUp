using Microsoft.AspNetCore.Identity;
using SkillUp.Core.Entities;
using SkillUp.Entity.Entities.Relations.ManyToMany;
using SkillUp.Entity.Entities.Reviews;
using SkillUp.Entity.Entities.Settings;

namespace SkillUp.Entity.Entities
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Wallet { get; set; }
        public string? ImageUrl { get; set; }


        public ICollection<AppUserCourse> AppUserCourses { get; set; }
        public ICollection<AppUserInstructor> AppUserInstructors { get; set; }
        public ICollection<AppUserProduct> AppUserProducts { get; set; }
        public ICollection<CourseReview> CourseReviews { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }

    }
}
