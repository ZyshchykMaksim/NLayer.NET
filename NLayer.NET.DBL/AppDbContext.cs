using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using NLayer.DAL.Entities;

namespace NLayer.DAL
{
    /// <summary>
    /// AppIdentityDbContext.
    /// </summary>
    public class AppDbContext : IdentityDbContextBase
    {
        private const string ConnectionString = "DefaultConnection";

        static AppDbContext()
        {
            Database.SetInitializer<AppDbContext>(new AppDbInitializer());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppIdentityDbContext" /> class.
        /// </summary>
        public AppDbContext() : base(ConnectionString) { }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public DbSet<ExternalData> ExternalDatas { get; set; }
        

        #region Overrides of DbContext

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are created for
        /// many-to-many relationships and relationships where there is no foreign key property
        /// included in the entity class (often referred to as independent associations).
        /// </returns>
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        
        /// <summary>
        /// Asynchronously saves all changes made in this context to the underlying database.
        /// </summary>
        /// <remarks>
        /// Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        /// that any asynchronous operations have completed before calling another method on this context.
        /// </remarks>
        /// <returns>
        /// A task that represents the asynchronous save operation.
        /// The task result contains the number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are created for
        /// many-to-many relationships and relationships where there is no foreign key property
        /// included in the entity class (often referred to as independent associations).
        /// </returns>
        public override Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
        }

        #endregion
    }
}
