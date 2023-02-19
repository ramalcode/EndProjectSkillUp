using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Reviews;
using System.Collections;

namespace SkillUp.Entity.ViewModels
{
    public class CorseDetailVM
    {
        public Course Course { get; set; }
        public ICollection<CourseReview> CourseReviews { get; set; }
    }
}
