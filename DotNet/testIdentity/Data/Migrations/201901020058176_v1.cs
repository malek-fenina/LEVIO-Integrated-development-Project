namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        State = c.Int(nullable: false),
                        Description = c.String(),
                        IdUser = c.Int(nullable: false),
                        Ressource_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ressource", t => t.Ressource_Id)
                .Index(t => t.Ressource_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Password = c.String(nullable: false),
                        UserRole = c.String(),
                        NbrRessource = c.Int(nullable: false),
                        NbrProjetActif = c.Int(nullable: false),
                        Image = c.String(),
                        TypeClient = c.String(),
                        LastName = c.String(),
                        RessourceType = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Competence",
                c => new
                    {
                        idCompetence = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false, maxLength: 30),
                        Dificulty = c.Int(nullable: false),
                        idRessource = c.Int(nullable: false),
                        Categorie_idCategorie = c.Int(),
                    })
                .PrimaryKey(t => t.idCompetence)
                .ForeignKey("dbo.Ressource", t => t.idRessource)
                .ForeignKey("dbo.Categorie", t => t.Categorie_idCategorie)
                .Index(t => t.idRessource)
                .Index(t => t.Categorie_idCategorie);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        idProject = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Date_Debut = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Date_Fin = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NbrRessourceTotal = c.Int(nullable: false),
                        NbrRessourceLevio = c.Int(nullable: false),
                        Image = c.String(),
                        idCompetence = c.Int(nullable: false),
                        projectTypes = c.Int(nullable: false),
                        IdClient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idProject)
                .ForeignKey("dbo.Users", t => t.IdClient, cascadeDelete: true)
                .ForeignKey("dbo.Competence", t => t.idCompetence, cascadeDelete: true)
                .Index(t => t.idCompetence)
                .Index(t => t.IdClient);
            
            CreateTable(
                "dbo.Level",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        Niveau = c.Int(nullable: false),
                        NbrAnnéesExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LevelId);
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        idMessage = c.Int(nullable: false, identity: true),
                        Contenu = c.String(),
                        Received = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UsersId = c.Int(nullable: false),
                        messageTypes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idMessage)
                .ForeignKey("dbo.Users", t => t.UsersId, cascadeDelete: true)
                .Index(t => t.UsersId);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Users_Id = c.Int(),
                        CustomRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .ForeignKey("dbo.CustomRoles", t => t.CustomRole_Id)
                .Index(t => t.Users_Id)
                .Index(t => t.CustomRole_Id);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        idRequest = c.Int(nullable: false, identity: true),
                        DateRequest = c.DateTime(nullable: false),
                        Education = c.String(),
                        Clients_Id = c.Int(),
                        Project_idProject = c.Int(),
                    })
                .PrimaryKey(t => t.idRequest)
                .ForeignKey("dbo.Client", t => t.Clients_Id)
                .ForeignKey("dbo.Project", t => t.Project_idProject)
                .Index(t => t.Clients_Id)
                .Index(t => t.Project_idProject);
            
            CreateTable(
                "dbo.Requirement",
                c => new
                    {
                        idRequirement = c.Int(nullable: false, identity: true),
                        Request_idRequest = c.Int(),
                    })
                .PrimaryKey(t => t.idRequirement)
                .ForeignKey("dbo.Request", t => t.Request_idRequest)
                .Index(t => t.Request_idRequest);
            
            CreateTable(
                "dbo.Vacance",
                c => new
                    {
                        VacanceId = c.Int(nullable: false, identity: true),
                        Date_Debut = c.DateTime(nullable: false),
                        Date_Fin = c.DateTime(nullable: false),
                        typeholiday = c.Int(nullable: false),
                        idRessource = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VacanceId)
                .ForeignKey("dbo.Ressource", t => t.idRessource)
                .Index(t => t.idRessource);
            
            CreateTable(
                "dbo.ApplicationTest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.Int(nullable: false),
                        Application_Id = c.Int(),
                        Test_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Application", t => t.Application_Id)
                .ForeignKey("dbo.Test", t => t.Test_Id)
                .Index(t => t.Application_Id)
                .Index(t => t.Test_Id);
            
            CreateTable(
                "dbo.Test",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeTest = c.String(),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        choice1 = c.String(),
                        choice2 = c.String(),
                        choice3 = c.String(),
                        ValidChoise = c.String(),
                        TestId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Test", t => t.TestId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.Categorie",
                c => new
                    {
                        idCategorie = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.idCategorie);
            
            CreateTable(
                "dbo.Leave",
                c => new
                    {
                        idLeave = c.Int(nullable: false, identity: true),
                        Date_Debut = c.DateTime(nullable: false),
                        Date_Fin = c.DateTime(nullable: false),
                        Purpose = c.String(),
                    })
                .PrimaryKey(t => t.idLeave);
            
            CreateTable(
                "dbo.Mandat",
                c => new
                    {
                        idMandat = c.Int(nullable: false, identity: true),
                        idProject = c.Int(nullable: false),
                        IdRessource = c.Int(nullable: false),
                        date_debut = c.DateTime(nullable: false),
                        date_fin = c.DateTime(nullable: false),
                        NomMandat = c.String(),
                    })
                .PrimaryKey(t => t.idMandat)
                .ForeignKey("dbo.Project", t => t.idProject, cascadeDelete: true)
                .ForeignKey("dbo.Ressource", t => t.IdRessource)
                .Index(t => t.idProject)
                .Index(t => t.IdRessource);
            
            CreateTable(
                "dbo.Note",
                c => new
                    {
                        idNote = c.Int(nullable: false, identity: true),
                        Contenu = c.String(),
                        Term_termId = c.Int(),
                    })
                .PrimaryKey(t => t.idNote)
                .ForeignKey("dbo.Term", t => t.Term_termId)
                .Index(t => t.Term_termId);
            
            CreateTable(
                "dbo.Resume",
                c => new
                    {
                        idResume = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Education = c.String(),
                    })
                .PrimaryKey(t => t.idResume);
            
            CreateTable(
                "dbo.CustomRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seniority",
                c => new
                    {
                        idSeniority = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.idSeniority);
            
            CreateTable(
                "dbo.Term",
                c => new
                    {
                        termId = c.Int(nullable: false, identity: true),
                        Date_Debut = c.DateTime(nullable: false),
                        Date_Fin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.termId);
            
            CreateTable(
                "dbo.LevelProjects",
                c => new
                    {
                        Level_LevelId = c.Int(nullable: false),
                        Project_idProject = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Level_LevelId, t.Project_idProject })
                .ForeignKey("dbo.Level", t => t.Level_LevelId, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.Project_idProject, cascadeDelete: true)
                .Index(t => t.Level_LevelId)
                .Index(t => t.Project_idProject);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        idClient = c.Int(nullable: false),
                        Nom = c.String(),
                        Prenom = c.String(),
                        clientTypes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Responsable",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        idResponsable = c.Int(nullable: false),
                        Nom = c.String(),
                        Prenom = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Ressource",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Level_LevelId = c.Int(),
                        Seniority_idSeniority = c.Int(),
                        idRessource = c.Int(nullable: false),
                        Nom = c.String(),
                        Prenom = c.String(),
                        BusinessSectors = c.Int(nullable: false),
                        Senioritys = c.String(),
                        CV = c.String(),
                        note = c.String(),
                        ressourceTypes = c.Int(nullable: false),
                        ressourceStates = c.Int(nullable: false),
                        profil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .ForeignKey("dbo.Level", t => t.Level_LevelId)
                .ForeignKey("dbo.Seniority", t => t.Seniority_idSeniority)
                .Index(t => t.Id)
                .Index(t => t.Level_LevelId)
                .Index(t => t.Seniority_idSeniority);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ressource", "Seniority_idSeniority", "dbo.Seniority");
            DropForeignKey("dbo.Ressource", "Level_LevelId", "dbo.Level");
            DropForeignKey("dbo.Ressource", "Id", "dbo.Users");
            DropForeignKey("dbo.Responsable", "Id", "dbo.Users");
            DropForeignKey("dbo.Client", "Id", "dbo.Users");
            DropForeignKey("dbo.Note", "Term_termId", "dbo.Term");
            DropForeignKey("dbo.CustomUserRoles", "CustomRole_Id", "dbo.CustomRoles");
            DropForeignKey("dbo.Mandat", "IdRessource", "dbo.Ressource");
            DropForeignKey("dbo.Mandat", "idProject", "dbo.Project");
            DropForeignKey("dbo.Competence", "Categorie_idCategorie", "dbo.Categorie");
            DropForeignKey("dbo.ApplicationTest", "Test_Id", "dbo.Test");
            DropForeignKey("dbo.Question", "TestId", "dbo.Test");
            DropForeignKey("dbo.ApplicationTest", "Application_Id", "dbo.Application");
            DropForeignKey("dbo.Application", "Ressource_Id", "dbo.Ressource");
            DropForeignKey("dbo.Vacance", "idRessource", "dbo.Ressource");
            DropForeignKey("dbo.Competence", "idRessource", "dbo.Ressource");
            DropForeignKey("dbo.Project", "idCompetence", "dbo.Competence");
            DropForeignKey("dbo.Requirement", "Request_idRequest", "dbo.Request");
            DropForeignKey("dbo.Request", "Project_idProject", "dbo.Project");
            DropForeignKey("dbo.Request", "Clients_Id", "dbo.Client");
            DropForeignKey("dbo.CustomUserRoles", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Project", "IdClient", "dbo.Users");
            DropForeignKey("dbo.Message", "UsersId", "dbo.Users");
            DropForeignKey("dbo.CustomUserLogins", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.CustomUserClaims", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.LevelProjects", "Project_idProject", "dbo.Project");
            DropForeignKey("dbo.LevelProjects", "Level_LevelId", "dbo.Level");
            DropIndex("dbo.Ressource", new[] { "Seniority_idSeniority" });
            DropIndex("dbo.Ressource", new[] { "Level_LevelId" });
            DropIndex("dbo.Ressource", new[] { "Id" });
            DropIndex("dbo.Responsable", new[] { "Id" });
            DropIndex("dbo.Client", new[] { "Id" });
            DropIndex("dbo.LevelProjects", new[] { "Project_idProject" });
            DropIndex("dbo.LevelProjects", new[] { "Level_LevelId" });
            DropIndex("dbo.Note", new[] { "Term_termId" });
            DropIndex("dbo.Mandat", new[] { "IdRessource" });
            DropIndex("dbo.Mandat", new[] { "idProject" });
            DropIndex("dbo.Question", new[] { "TestId" });
            DropIndex("dbo.ApplicationTest", new[] { "Test_Id" });
            DropIndex("dbo.ApplicationTest", new[] { "Application_Id" });
            DropIndex("dbo.Vacance", new[] { "idRessource" });
            DropIndex("dbo.Requirement", new[] { "Request_idRequest" });
            DropIndex("dbo.Request", new[] { "Project_idProject" });
            DropIndex("dbo.Request", new[] { "Clients_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "CustomRole_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "Users_Id" });
            DropIndex("dbo.Message", new[] { "UsersId" });
            DropIndex("dbo.CustomUserLogins", new[] { "Users_Id" });
            DropIndex("dbo.Project", new[] { "IdClient" });
            DropIndex("dbo.Project", new[] { "idCompetence" });
            DropIndex("dbo.Competence", new[] { "Categorie_idCategorie" });
            DropIndex("dbo.Competence", new[] { "idRessource" });
            DropIndex("dbo.CustomUserClaims", new[] { "Users_Id" });
            DropIndex("dbo.Application", new[] { "Ressource_Id" });
            DropTable("dbo.Ressource");
            DropTable("dbo.Responsable");
            DropTable("dbo.Client");
            DropTable("dbo.LevelProjects");
            DropTable("dbo.Term");
            DropTable("dbo.Seniority");
            DropTable("dbo.CustomRoles");
            DropTable("dbo.Resume");
            DropTable("dbo.Note");
            DropTable("dbo.Mandat");
            DropTable("dbo.Leave");
            DropTable("dbo.Categorie");
            DropTable("dbo.Question");
            DropTable("dbo.Test");
            DropTable("dbo.ApplicationTest");
            DropTable("dbo.Vacance");
            DropTable("dbo.Requirement");
            DropTable("dbo.Request");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.Message");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.Level");
            DropTable("dbo.Project");
            DropTable("dbo.Competence");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Application");
        }
    }
}
