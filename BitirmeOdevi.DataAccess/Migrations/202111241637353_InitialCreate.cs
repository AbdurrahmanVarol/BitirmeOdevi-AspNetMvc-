namespace BitirmeOdevi.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ad = c.String(),
                        soyad = c.String(),
                        kullaniciAd = c.String(),
                        sifre = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Yillars",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        yil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Yillars");
            DropTable("dbo.Kullanicis");
        }
    }
}
