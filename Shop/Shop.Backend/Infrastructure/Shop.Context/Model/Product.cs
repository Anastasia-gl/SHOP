using System;
using System.Collections.Generic;

namespace Shop.Context.Model
{
    public partial class Product
    {
        public Product()
        {
            ProductBaskets = new HashSet<ProductBasket>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public string? Decription { get; set; }
        public string? PhotoUrl { get; set; }
        public int TypeId { get; set; }
        public int CharacteristicId { get; set; }

        public virtual Characteristic Characteristic { get; set; } = null!;
        public virtual TypeProduct Type { get; set; } = null!;
        public virtual ICollection<ProductBasket> ProductBaskets { get; set; }
    }
}
