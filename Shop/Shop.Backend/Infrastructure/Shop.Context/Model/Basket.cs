using System;
using System.Collections.Generic;

namespace Shop.Context.Model
{
    public partial class Basket
    {
        public Basket()
        {
            Histories = new HashSet<History>();
            ProductBaskets = new HashSet<ProductBasket>();
        }

        public int BasketId { get; set; }
        public int UserId { get; set; }

        public virtual UserProfile User { get; set; } = null!;
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<ProductBasket> ProductBaskets { get; set; }
    }
}
