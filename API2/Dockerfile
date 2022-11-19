FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV ASPNETCORE_URLS=http://*:8082
ENV api2Settings__value1=value1-dockerfile
ENV api2Settings__value2=value2-dockerfile
COPY ./API2/bin/Release/net6.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "API2.dll"]