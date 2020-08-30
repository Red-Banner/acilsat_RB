namespace acilsat_RB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string userName { get; set; }

        [Required]
        [StringLength(12)]
        public string userPassword { get; set; }

        [StringLength(30)]
        public string name { get; set; }

        [StringLength(10)]
        public string surName { get; set; }

        [StringLength(50)]
        public string eMail { get; set; }

        [StringLength(15)]
        public string userPhone { get; set; }

        [StringLength(30)]
        public string userCity { get; set; }

        [Column(TypeName = "image")]
        public byte[] userImage { get; set; }
    }
}
