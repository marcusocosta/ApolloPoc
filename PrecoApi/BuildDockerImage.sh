dotnet clean
dotnet restore
dotnet publish -c Release -o out

docker build -t precoapi:$1 ./src/WebApi/

