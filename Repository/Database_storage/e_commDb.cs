namespace Repository.Database_storage
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class e_commDb : DbContext
    {
        public e_commDb()
            : base("name=e_commDb")
        {
        }

        public virtual DbSet<ecom_tbl_Category> ecom_tbl_Category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ecom_tbl_Category>()
                .Property(e => e.ct_Id)
                .IsUnicode(false);

            modelBuilder.Entity<ecom_tbl_Category>()
                .Property(e => e.ct_Name)
                .IsUnicode(false);

            modelBuilder.Entity<ecom_tbl_Category>()
                .Property(e => e.ct_Type)
                .IsUnicode(false);

            modelBuilder.Entity<ecom_tbl_Category>()
                .Property(e => e.ct_Modified_By)
                .IsUnicode(false);
        }
    }
}
