namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "BusinessSectors", c => c.String());
            AddColumn("dbo.Users", "Senioritys", c => c.String());
            AddColumn("dbo.Users", "CV", c => c.String());
            AddColumn("dbo.Users", "note", c => c.String());
            AddColumn("dbo.Users", "ressourceTypes", c => c.String());
            AddColumn("dbo.Users", "ressourceStates", c => c.String());
            AddColumn("dbo.Users", "profil", c => c.String());
            DropColumn("dbo.Ressource", "BusinessSectors");
            DropColumn("dbo.Ressource", "Senioritys");
            DropColumn("dbo.Ressource", "CV");
            DropColumn("dbo.Ressource", "note");
            DropColumn("dbo.Ressource", "ressourceTypes");
            DropColumn("dbo.Ressource", "ressourceStates");
            DropColumn("dbo.Ressource", "profil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ressource", "profil", c => c.Int(nullable: false));
            AddColumn("dbo.Ressource", "ressourceStates", c => c.Int(nullable: false));
            AddColumn("dbo.Ressource", "ressourceTypes", c => c.Int(nullable: false));
            AddColumn("dbo.Ressource", "note", c => c.String());
            AddColumn("dbo.Ressource", "CV", c => c.String());
            AddColumn("dbo.Ressource", "Senioritys", c => c.String());
            AddColumn("dbo.Ressource", "BusinessSectors", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "profil");
            DropColumn("dbo.Users", "ressourceStates");
            DropColumn("dbo.Users", "ressourceTypes");
            DropColumn("dbo.Users", "note");
            DropColumn("dbo.Users", "CV");
            DropColumn("dbo.Users", "Senioritys");
            DropColumn("dbo.Users", "BusinessSectors");
        }
    }
}
