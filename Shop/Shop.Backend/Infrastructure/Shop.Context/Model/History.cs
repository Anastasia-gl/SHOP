using System;
using System.Collections.Generic;

namespace Shop.Context.Model
{
    public partial class History
    {
        public int HistoryId { get; set; }
        public int? BasketId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Telephone { get; set; }
        public string? Address { get; set; }

        public virtual Basket? Basket { get; set; }
    }
}
