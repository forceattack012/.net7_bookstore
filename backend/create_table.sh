cd ./bookApi.Infrastructure 

dotnet ef migrations add InitialCreate
dotnet ef database update

$SHELL