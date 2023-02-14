using SkillUp.Core.Entities;
using SkillUp.Entity.Entities.Relations.ProductExtraProperities;

namespace SkillUp.Entity.Entities.Relations.ManyToMany
{
    public class ProductAuthor:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
