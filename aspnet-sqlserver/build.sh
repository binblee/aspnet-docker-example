#!/bin/bash

dotnet restore
dotnet publish -c release
docker build -t aspnet-sqlserver .
