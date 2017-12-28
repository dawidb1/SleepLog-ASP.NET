namespace SleepLogASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        morningRating = c.Int(nullable: false),
                        eveningRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatingID);
            
            CreateTable(
                "dbo.Sleep",
                c => new
                    {
                        sleepID = c.Int(nullable: false, identity: true),
                        note = c.String(),
                        rating_RatingID = c.Int(),
                        sleepTime_SleepTimeID = c.Int(),
                    })
                .PrimaryKey(t => t.sleepID)
                .ForeignKey("dbo.Rating", t => t.rating_RatingID)
                .ForeignKey("dbo.SleepTime", t => t.sleepTime_SleepTimeID)
                .Index(t => t.rating_RatingID)
                .Index(t => t.sleepTime_SleepTimeID);
            
            CreateTable(
                "dbo.SleepTime",
                c => new
                    {
                        SleepTimeID = c.Int(nullable: false, identity: true),
                        startSleep = c.DateTime(nullable: false),
                        endSleep = c.DateTime(nullable: false),
                        amountOfSleep = c.Time(nullable: false, precision: 7),
                        dayOfWeek = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SleepTimeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sleep", "sleepTime_SleepTimeID", "dbo.SleepTime");
            DropForeignKey("dbo.Sleep", "rating_RatingID", "dbo.Rating");
            DropIndex("dbo.Sleep", new[] { "sleepTime_SleepTimeID" });
            DropIndex("dbo.Sleep", new[] { "rating_RatingID" });
            DropTable("dbo.SleepTime");
            DropTable("dbo.Sleep");
            DropTable("dbo.Rating");
        }
    }
}
