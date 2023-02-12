using SkillUp.Core.Entities;
using SkillUp.Entity.Entities.Relations.ManyToMany;

namespace SkillUp.Entity.Entities
{
    public class Product:BaseNameableEntity
    {
        public byte Quantity { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public string ImageUrl { get; set; }


        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<AppUserProduct> AppUserProducts { get; set; }

    }
}
