# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

USER root

EXPOSE 5126

WORKDIR /app

COPY . /app/

ENTRYPOINT ["dotnet", "TripBooking.ServiceHost.dll"]