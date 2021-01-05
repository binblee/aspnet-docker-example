# ASP.NET Application on Docker/Aliyun Container Service

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

Run helloworld locally.

```
dotnet run
```

Compile and build Docker image.

```
dotnet restore
dotnet publish
docker build -t dotnet-helloworld .
```
Or run it in a build script.

```
./build.sh
```

Publish to Aliyun CS hub, replace ```<name>``` with your aliyun registry name.

```
docker tag dotnet-helloworld registry.aliyuncs.com/<name>/dotnet-helloworld
docker push registry.aliyuncs.com/<name>/dotnet-helloworld
```
