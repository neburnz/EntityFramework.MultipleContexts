namespace FirstClassLibrary.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("first.Countries")]
    public partial class Country
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public int CountryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(4)]
        public string Code { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? Order { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
