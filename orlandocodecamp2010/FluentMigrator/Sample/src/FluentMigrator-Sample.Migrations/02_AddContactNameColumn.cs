using FluentMigrator;

namespace FluentMigrator_Sample.Migrations
{
   [Migration(2)]
   public class AddContactNameColumn : Migration
   {
      public override void Up()
      {
         Create.Column( "ContactName" )
            .OnTable( "Companies" )
            .AsString( 200 );
      }

      public override void Down()
      {
         Delete.Column( "ContactName" )
            .FromTable( "Companies" );
      }
   }
}
