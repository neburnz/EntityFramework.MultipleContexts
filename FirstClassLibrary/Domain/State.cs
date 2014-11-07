namespace FirstClassLibrary.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("first.States")]
    public partial class State
    {
        public int StateID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int CountryID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Budget { get; set; }

        public virtual Country Country { get; set; }
    }
}
