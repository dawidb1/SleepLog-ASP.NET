namespace SleepLogASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFirstName : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Sleep", new[] { "rating_RatingID" });
            DropIndex("dbo.Sleep", new[] { "sleepTime_SleepTimeID" });
            CreateIndex("dbo.Sleep", "Rating_RatingID");
            CreateIndex("dbo.Sleep", "SleepTime_SleepTimeID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Sleep", new[] { "SleepTime_SleepTimeID" });
            DropIndex("dbo.Sleep", new[] { "Rating_RatingID" });
            CreateIndex("dbo.Sleep", "sleepTime_SleepTimeID");
            CreateIndex("dbo.Sleep", "rating_RatingID");
        }
    }
}
