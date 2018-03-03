namespace Events.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        country_id = c.Int(nullable: false),
                        creator = c.String(),
                        created = c.DateTime(),
                        changer = c.String(),
                        changed = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.countries", t => t.country_id, cascadeDelete: false )
                .Index(t => t.country_id);
            
            CreateTable(
                "dbo.countries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        creator = c.String(),
                        created = c.DateTime(),
                        changer = c.String(),
                        changed = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.events",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false),
                        start_date = c.DateTime(nullable: false),
                        end_date = c.DateTime(nullable: false),
                        country_id = c.Int(nullable: false),
                        city_id = c.Int(nullable: false),
                        location = c.String(nullable: false),
                        image_path = c.String(nullable: false),
                        description = c.String(),
                        creator = c.String(),
                        created = c.DateTime(),
                        changer = c.String(),
                        changed = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cities", t => t.city_id, cascadeDelete: false)
                .ForeignKey("dbo.countries", t => t.country_id, cascadeDelete: false)
                .Index(t => t.country_id)
                .Index(t => t.city_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.events", "country_id", "dbo.countries");
            DropForeignKey("dbo.events", "city_id", "dbo.cities");
            DropForeignKey("dbo.cities", "country_id", "dbo.countries");
            DropIndex("dbo.events", new[] { "city_id" });
            DropIndex("dbo.events", new[] { "country_id" });
            DropIndex("dbo.cities", new[] { "country_id" });
            DropTable("dbo.events");
            DropTable("dbo.countries");
            DropTable("dbo.cities");
        }
    }
}
