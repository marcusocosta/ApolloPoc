FROM microsoft/dotnet:aspnetcore-runtime

COPY ./out ./app

WORKDIR /app

ENTRYPOINT ["dotnet", "WebApi.dll"]
