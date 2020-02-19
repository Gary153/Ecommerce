namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserDetail
    {
        [Key]
        public int UserDetailsId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [StringLength(128)]
        public string UserCity { get; set; }

        [StringLength(128)]
        public string UserState { get; set; }

        [StringLength(50)]
        public string UserZip { get; set; }

        public DateTime? UserRegistrationDate { get; set; }

        [StringLength(128)]
        public string UserIp { get; set; }

        [StringLength(128)]
        public string UserCountry { get; set; }

        [StringLength(128)]
        public string UserAddress1 { get; set; }

        [StringLength(10)]
        public string UserAddress2 { get; set; }

        public virtual User User { get; set; }
    }
}
