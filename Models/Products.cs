namespace acilsat_RB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        public int Id { get; set; }

        public int? productNo { get; set; }

        [StringLength(100)]
        public string productName { get; set; }

        public int? categoryNo { get; set; }

        public decimal? productPrice { get; set; }

        [StringLength(2000)]
        public string productDescription { get; set; }

        [Column(TypeName = "image")]
        public byte[] produtcImage1 { get; set; }

        [Column(TypeName = "image")]
        public byte[] productImage2 { get; set; }
    }
}
