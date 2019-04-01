dotnet clean
dotnet restore
dotnet publish -c Release -o out

docker build -t produtoapi:$1 ./src/WebApi/

