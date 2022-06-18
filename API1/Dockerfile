FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY API1/bin/Release/net6.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "API1.dll"]