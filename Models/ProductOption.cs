namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductOption
    {
        public int ProductOptionId { get; set; }

        public int? OptionsId { get; set; }

        public int? ProductId { get; set; }

        public int? OptionGroupId { get; set; }

        public double? OptionPriceIncrement { get; set; }

        public virtual OptionGroup OptionGroup { get; set; }

        public virtual Option Option { get; set; }

        public virtual Product Product { get; set; }
    }
}
