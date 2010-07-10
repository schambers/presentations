using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace FluentMigrator_Sample.Migrations
{
   [Migration(4)]
   public class InsertEmployees : Migration
   {
      public override void Up()
      {
         Insert.IntoTable( "Employees" ).Row( new {Prefix = "Mr.", FirstName = "Keyser", LastName = "Soze"} );
         Insert.IntoTable("Employees").Row(new { Prefix = "Mr.", FirstName = "Mickey", LastName = "Mouse" });
      }

      public override void Down()
      {
         Execute.Sql( "DELETE FROM Employees WHERE FirstName='Keyser' AND LastName='Soze'" );
         Execute.Sql("DELETE FROM Employees WHERE FirstName='Mickey' AND LastName='Mouse'");
      }
   }
}
