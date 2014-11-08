namespace SecondClassLibrary.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("second.Addresses")]
    public partial class Address
    {
        public int AddressID { get; set; }

        [Required]
        [StringLength(50)]
        public string StreetName { get; set; }

        public short? StreetNumber { get; set; }

        public int? PersonID { get; set; }

        public virtual Person Person { get; set; }
    }
}
