# ASP.NET Application to SQLServer on Docker

## Setup .NET Core on Mac

Following the steps in [https://www.microsoft.com/net/core#macosx](https://www.microsoft.com/net/core#macosx) to install .NET Core on Mac.


### Install pre-requisites
```
brew update
brew install openssl
brew link --force openssl
```

### Install .NET Core SDK

Run installer from [official installer](https://go.microsoft.com/fwlink/?LinkID=809124), all set.

### Optinal: install VS Code

Download [Visual Studio Code](https://code.visualstudio.com/Download)

Extract the package and move bin file to Application folder.

## Compile, Run and Push Docker Image

### Create SQLServer instance and database

Create a SQLServer instance in Ali Cloud, add IP whitelist to allow access from everywhere.
Request a public address. Create a database, a user, grant user to access
the database.

### Create tables in SQLServer using ef

```
dotnet restore
dotnet ef migrations add MyFirstMigration
dotnet ef database update
```

Run helloworld locally.

```
export SQLSERVER_ADDRESS=...
export SQLSERVER_PORT=...
export SQLSERVER_USERNAME=...
export SQLSERVER_PASSWORD=...
dotnet run
```

Compile and build Docker image.

```
dotnet restore
dotnet publish -c release
docker build -t aspnet-sqlserver .
```
Or run it in a build script.

```
./build.sh
```

Publish to Aliyun CS hub, replace ```<name>``` with your aliyun registry name.

```
docker tag dotnet-helloworld registry.aliyuncs.com/<name>/aspnet-sqlserver
docker push registry.aliyuncs.com/<name>/aspnet-sqlserver
```
