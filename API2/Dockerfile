FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV ASPNETCORE_URLS=https://*:8001;http://*:8000
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/my_pkcs12.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="long@126"
ENV api2Settings__value1=value1-dockerfile
ENV api2Settings__value2=value2-dockerfile
COPY ./API2/bin/Release/net6.0/publish/ App/
RUN mkdir -p /https
COPY my_pkcs12.pfx /https
WORKDIR /App
ENTRYPOINT ["dotnet", "API2.dll"]