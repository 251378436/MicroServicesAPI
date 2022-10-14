FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY ./API3/bin/Release/net6.0/linux-x64/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "API3.dll"]