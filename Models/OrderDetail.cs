namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        [Key]
        public int DetailsId { get; set; }

        public int? OrderId { get; set; }

        public int? ProductId { get; set; }

        [StringLength(130)]
        public string DetailsName { get; set; }

        public double? DetailsPrice { get; set; }

        public int? DetailsQuantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
