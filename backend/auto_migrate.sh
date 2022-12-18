cd ./bookApi.Infrastructure 

dotnet ef migrations add $1
dotnet ef database update

$SHELL