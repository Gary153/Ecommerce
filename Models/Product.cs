namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Galleries = new HashSet<Gallery>();
            OrderDetails = new HashSet<OrderDetail>();
            ProductFeatures = new HashSet<ProductFeature>();
            ProductOptions = new HashSet<ProductOption>();
        }

        public int ProductId { get; set; }

        [StringLength(130)]
        public string ProductName { get; set; }

        public double? ProductPrice { get; set; }

        public double? ProductWeight { get; set; }

        [StringLength(300)]
        public string ProductCartDesc { get; set; }

        [StringLength(300)]
        public string ProductShortDesc { get; set; }

        public string ProductLongDesc { get; set; }

        public int? CategoryId { get; set; }

        public DateTime? DateCreated { get; set; }

        [StringLength(10)]
        public string DateModified { get; set; }

        public double? ProductStock { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gallery> Galleries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOption> ProductOptions { get; set; }
    }
}
