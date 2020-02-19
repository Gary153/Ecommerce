namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gallery")]
    public partial class Gallery
    {
        public int GalleryId { get; set; }

        public byte[] Image { get; set; }

        [StringLength(130)]
        public string ImageName { get; set; }

        [StringLength(10)]
        public string ImageType { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
