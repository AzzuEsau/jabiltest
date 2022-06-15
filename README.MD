## Migrations 

To create a migration file use the next commands

        dotnet ef migrations add firstmigration --project api.csproj

Then change the name of the tables to use lowercase, to upload the tables use the next command

        dotnet ef database update

To check the status of the build use the next command

        dotnet build 

