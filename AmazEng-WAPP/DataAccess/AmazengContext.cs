using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace AmazEng_WAPP.DataAccess
{
    public class AmazengContext : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AmazEng_WAPP.Models.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public AmazengContext()
            : base("name=amazeng")
        {
            //Database.Log = Console.WriteLine;
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminRole> AdminRoles { get; set; }
        public DbSet<Idiom> Idioms { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<LibraryIdiom> LibraryIdioms { get; set; }
        public DbSet<LibraryType> LibraryTypes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Idiom>().HasMany(i => i.Tags).WithMany(t => t.Idioms).Map(it =>
            {
                it.MapLeftKey("IdiomId");
                it.MapRightKey("TagId");
                it.ToTable("IdiomTags");
            });

        }

        internal Member GetMemberByUsername(string username)
        {
            return this.Members.Where(m => m.Username == username && m.DeletedAt == null).First();
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<ICustomSoftDelete>().Where(e => e.State == EntityState.Deleted))
            {
                var entity = entry.Entity;
                entry.State = EntityState.Modified;
                entry.CurrentValues["DeletedAt"] = DateTime.UtcNow;
            }

            foreach (var entry in ChangeTracker.Entries<IHasTimeStamp>().Where(e => e.State == EntityState.Modified))
            {
                entry.Entity.ModifiedAt = DateTime.UtcNow;
            }

            foreach (var entry in ChangeTracker.Entries<IHasTimeStamp>().Where(e => e.State == EntityState.Added))
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }

            foreach (var entry in ChangeTracker.Entries<Member>().Where(e => e.State == EntityState.Added))
            {
                var member = entry.Entity;
                member.Libraries = new List<Library>();

                member.Libraries.Add(new Library
                {
                    LibraryTypeId = LibraryType.GetFavouriteLibraryType().Id,
                });
                member.Libraries.Add(new Library
                {
                    LibraryTypeId = LibraryType.GetHistoryLibraryType().Id,
                });
                member.Libraries.Add(new Library
                {
                    LibraryTypeId = LibraryType.GetLearnLaterLibraryType().Id,
                });
            }

            foreach (var entry in ChangeTracker.Entries<LibraryIdiom>().Where(e => e.State == EntityState.Added))
            {
                var libraryIdiom = entry.Entity;
                libraryIdiom.AddedAt = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public AdminRole GetSuperAdminRole()
        {
            return this.AdminRoles.Where(adminRole => adminRole.Name == "Super Admin").First();
        }

        public AdminRole GetNormalAdminRole()
        {
            return this.AdminRoles.Where(adminRole => adminRole.Name == "Admin").First();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}