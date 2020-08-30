namespace acilsat_RB.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class acilsatDB : DbContext
    {
        public acilsatDB()
            : base("name=acilsatDBEntities")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Users>()
                .Property(e => e.surName)
                .IsFixedLength();

            modelBuilder.Entity<Users>()
                .Property(e => e.userPhone)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
