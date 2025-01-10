
Run the all containers :

docker-compose up -d
http://localhost:9200
http://localhost:5601

Test the redis container :


Add-Migration dbVersion_01 -Context ApplicationDbContext -StartupProject Hydra.Web

Update-Database -Context ApplicationDbContext -verbose -StartupProject Hydra.Web


Remove-Migration -Context ApplicationDbContext -StartupProject Hydra.Web




===============================================================================

Update-Database dbVersion_ -Context MigrationContext -verbose

Remove-Migration -Context MigrationContext -StartupProject Hydra.Web


Update-database MyInitialMigration -Context MigrationContext -verbose


-- remove migration
Update-Database -Migration 0 -Context ApplicationDbContext  -StartupProject Hydra.Web
Remove-Migration -Context ApplicationDbContext -StartupProject Hydra.Web