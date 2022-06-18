FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY API2/bin/Release/net6.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "API2.dll"]