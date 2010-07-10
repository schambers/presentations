lib\FluentMigrator.Console.exe /db sqlserver /connection "Data Source=localhost;Initial Catalog=FluentMigrator;Integrated Security=True" /target "src/FluentMigrator-Sample.Migrations/bin/Debug/FluentMigrator-Sample.Migrations.dll" /task migrate /steps 1
REM /workingdirectory "seed_data"
pause