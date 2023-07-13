
Run the all containers :

docker-compose up -d
http://localhost:9200
http://localhost:5601

Test the redis container :


Add-Migration dbVersion_1 -Context MigrationContext -StartupProject Hydra.Web


Update-Database -Context MigrationContext -verbose


Update-Database dbVersion_12 -Context MigrationContext -verbose

Remove-Migration -Context MigrationContext -StartupProject Hydra.Web
