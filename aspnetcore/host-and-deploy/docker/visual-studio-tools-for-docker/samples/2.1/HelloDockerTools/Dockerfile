# See https://aka.ms/containerimagehelp for information on how to use Windows Server 1709 containers with Service Fabric.
# FROM microsoft/aspnetcore:2.0-nanoserver-1709
FROM microsoft/aspnetcore:2.0-nanoserver-sac2016
ARG source
WORKDIR /app
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "HelloDockerTools.dll"]
