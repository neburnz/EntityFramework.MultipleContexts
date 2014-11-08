namespace SecondClassLibrary.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("second.People")]
    public partial class Person
    {
        public Person()
        {
            Addresses = new HashSet<Address>();
        }

        public int PersonID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool? Married { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
