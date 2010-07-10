using FluentMigrator;

namespace FluentMigrator_Sample.Migrations
{
   [Migration(1)]
   public class Baseline : Migration
   {
      public override void Up()
      {
         Create.Table("Companies")
            .WithColumn("Id").AsInt32().PrimaryKey()
            .WithColumn("Name").AsString(200)
            .WithColumn("Address").AsString(200);
      }

      public override void Down()
      {
         Delete.Table("Companies");
      }
   }
}
