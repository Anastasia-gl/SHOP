using System;
using System.Collections.Generic;

namespace Shop.Context.Model
{
    public partial class TypeProduct
    {
        public TypeProduct()
        {
            Products = new HashSet<Product>();
        }

        public int TypeId { get; set; }
        public string? TypeName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
