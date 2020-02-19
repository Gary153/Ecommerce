namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductFeature")]
    public partial class ProductFeature
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductFeatureId { get; set; }

        public int? ProductId { get; set; }

        public int? FeatureId { get; set; }

        public int? FeatureOptionId { get; set; }

        public double? FeaturePriceIncrement { get; set; }

        public virtual Feature Feature { get; set; }

        public virtual FeatureOption FeatureOption { get; set; }

        public virtual Product Product { get; set; }
    }
}
