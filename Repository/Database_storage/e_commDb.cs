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

        static e_commDb()
        {
            Database.SetInitializer<e_commDb>(null);
        }
        public virtual DbSet<CoreModel.Mappings.ecom_tbl_Category> ecom_tbl_Category { get; set; }
        public virtual DbSet<CoreModel.Mappings.ecom_tbl_Sub_Category> ecom_tbl_Sub_Category { get; set; }
        public virtual DbSet<CoreModel.Mappings.ecom_tbl_User> ecom_tbl_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CoreModel.Mappings.ecom_tbl_Category>();
            modelBuilder.Entity<CoreModel.Mappings.ecom_tbl_Sub_Category>();
            modelBuilder.Entity<CoreModel.Mappings.ecom_tbl_User>();
        }
        private void FixEfProviderServicesProblem()
        {
            // The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            // for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            // Make sure the provider assembly is available to the running application. 
            // See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
