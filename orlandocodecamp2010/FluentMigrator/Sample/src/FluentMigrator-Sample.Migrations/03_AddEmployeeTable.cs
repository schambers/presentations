using FluentMigrator;

namespace FluentMigrator_Sample.Migrations
{
   [Migration(3)]
   public class AddEmployeeTable : Migration
   {
      public override void Up()
      {
         Create.Table("Employees")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("CompanyId").AsInt32().ForeignKey().Nullable()
            .WithColumn("Prefix").AsString(10).WithDefaultValue("Mr.")
            .WithColumn("FirstName").AsString(200)
            .WithColumn( "LastName" ).AsString(200);

         Create.ForeignKey()
            .FromTable( "Employees" ).ForeignColumn( "CompanyId" )
            .ToTable( "Companies" ).PrimaryColumn( "Id" );

         //Create.Table(  )
         //Create.Column(  )
         //Create.ForeignKey()
         //Create.Index()

         //Delete.Table(  )
         // etc.

         //Rename.Column(  )
         //Rename.Table(  )

         //Execute.Sql(  );
         //Execute.Script(  );  // works from /working_directory
      }

      public override void Down()
      {
         Delete.ForeignKey( "FK_Employees_CompanyId_Companies_Id" )
            .OnTable( "Employees" );

         Delete.Table("Employees");
      }
   }
}
