# syntax=docker/dockerfile:1

# Create a stage for building the application.
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

COPY ../Entities /source/Entities
COPY ../Security /source/Security

WORKDIR /source/Security

ARG TARGETARCH

RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish -a ${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app
COPY ../Security/.env /app


FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app


COPY --from=build /app .

USER $APP_UID

ENTRYPOINT ["dotnet", "Security.dll"]
