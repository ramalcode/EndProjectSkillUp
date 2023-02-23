using SkillUp.Core.Entities;

namespace SkillUp.Entity.Entities.Reviews
{
    public class CourseReview:BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public string ReviewContent { get; set; }
        public DateTime ReviewDate { get; set; }
        public bool Status { get; set; }
    }
}
