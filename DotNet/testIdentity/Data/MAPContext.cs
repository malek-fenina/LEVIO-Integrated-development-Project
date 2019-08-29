using Microsoft.AspNet.Identity.EntityFramework;
using Domain.Entity;
using System.Data.Entity;

namespace Data
{
   public class MAPContext : IdentityDbContext<Users, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public static MAPContext Create()
        {
            return new MAPContext();
        }

        static MAPContext()
        {
            Database.SetInitializer<MAPContext>(null);
        }
        public MAPContext() : base("name=DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>().ToTable("Categorie");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Ressource>().ToTable("Ressource");
            modelBuilder.Entity<Competence>().ToTable("Competence");
          //  modelBuilder.Entity<BusinessSector>().ToTable("BusinessSector");
            modelBuilder.Entity<Leave>().ToTable("Leave");
            modelBuilder.Entity<Level>().ToTable("Level");
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<Note>().ToTable("Note");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Request>().ToTable("Request");
            modelBuilder.Entity<Requirement>().ToTable("Requirement");
            modelBuilder.Entity<Responsable>().ToTable("Responsable");
            modelBuilder.Entity<Resume>().ToTable("Resume");
            modelBuilder.Entity<Seniority>().ToTable("Seniority");
            modelBuilder.Entity<Term>().ToTable("Term");
            modelBuilder.Entity<Vacance>().ToTable("Vacance");
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Application>().ToTable("Application");
            modelBuilder.Entity<ApplicationTest>().ToTable("ApplicationTest");
            modelBuilder.Entity<Test>().ToTable("Test");
            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<Mandat>().ToTable("Mandat");

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Competence> Competences { get; set; }
      //  public DbSet<BusinessSector> BusinessSectors { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Level> Levels { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Request> Requests { get; set; }

        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Responsable> Responsables { get; set; }
    
        public DbSet<Ressource> Ressources { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Seniority> Senioritys { get; set; }

        public DbSet<Term> Terms { get; set; }

        public DbSet<Vacance> Vacances { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<ApplicationTest> ApplicationTest { get; set; }

        public DbSet<Test> Test { get; set; }

        public DbSet<Question> Question { get; set; }
        public DbSet<Mandat> Mandats { get; set; }


    }
}
