FROM microsoft/dotnet:latest
COPY bin/release/netcoreapp1.0/publish/ /app/
EXPOSE 5000/tcp
ENTRYPOINT dotnet /app/aspnet-helloworld.dll