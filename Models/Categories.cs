namespace acilsat_RB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Categories
    {
        [Key]
        public int categoryNo { get; set; }

        [StringLength(50)]
        public string categoryName { get; set; }
    }
}
