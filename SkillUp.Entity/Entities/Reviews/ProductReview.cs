using SkillUp.Core.Entities;

namespace SkillUp.Entity.Entities.Reviews
{
    public class ProductReview:BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser Appuser { get; set; }
        public int ProductId { get; set; }
        public string ReviewContent { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
    }
}
