# azconf21-demo
Repo holding the scripts for azure resource creation and dotnet microservice with cosmos backend

## Azure architecture
![Deployment Architecture](https://swaminathanvetri.blob.core.windows.net/blog-images/azconf-architecture.png)

## Azure resources creation
Check out the resources.azcli file to create the necessary azure resources to run this application

- Azure front door needs to be manually created in the azure portal

## dotnet webapi deployment to azure
- Make use of Visual Studio or Visual studio code extensions to deploy directly to Azure webapp using publish profile
- Change the connection endpoint, key and region in the cosmos context file and repository file before deployment
