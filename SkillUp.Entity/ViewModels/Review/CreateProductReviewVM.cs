using SkillUp.Entity.Entities;

namespace SkillUp.Entity.ViewModels
{
    public class CreateProductReviewVM
    {
        public string ReviewContent { get; set; }
        public int ProductId { get; set; }
        public Product? Course { get; set; }
    }
}
