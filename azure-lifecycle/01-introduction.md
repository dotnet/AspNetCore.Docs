# Introduction

## Welcome

Welcome to Azure Development Lifecycle for .NET! In this guide, we'll introduce you to the basic concepts you'll need to build a development lifecycle around Azure using .NET tools and processes. After finishing this guide, you'll be able to reap the benefits of a mature CI/CD DevOps toolchain.

### Who this guide is for

You should be an experienced ASP.NET developer (200-300 level). You don't need to know anything about Azure, as we'll cover that in this introduction. This guide may also be useful for DevOps engineers who are more focused on operations than development.

### What this guide doesn't cover

This guide is focused on an end-to-end DevOps experience for .NET developers. It will not be an exhaustive guide to all things Azure, nor will it focus extensively on .NET APIs for Azure services. The emphasis is all around continuous integration, deployment, monitoring, and debugging. Near the end of the guide we will make some recommendations for next steps, which will include some suggestions for Azure platform services that will be useful for ASP.NET developers.

## Understanding cloud computing as a developer

In many ways, developing for the cloud is very similar to developing on-premise applications. The most obvious difference is that the application code runs somewhere else. Getting a little deeper, however, things can get very complicated very quickly. For that reason, it's important to understand the different models of cloud computing.

%TODO% IaaS vs PaaS vs SaaS diagram like [this](https://stack247.files.wordpress.com/2015/05/azure-on-premises-vs-iaas-vs-paas-vs-saas.png)

### Infrastructure as a Service

The most familiar model of cloud computing for many developers is **Infrastructure as a Service**, or **IaaS**. In **IaaS** deployments, the customer is simply running a virtual machine on the service provider's hardware. While the cloud service provider is providing the physical infrastructure for network connectivity, physical storage, and a hypervisor to host the VM, the customer is responsible for the configuration and maintenance of the guest operating system within the VM, the virtual network configuration, and all the application code running within the VM.

IaaS is an attractive option for legacy applications, as generally anything that can be run on a VM on-premise can be run in a VM in a cloud data center just as well with few, if any, modifications.

### Platform as a Service

A cloud computing model which might be less familiar is **Platform as a Service**, or **PaaS**. PaaS services are about providing a development platform, with very little concern to the developer with regard to the underlying infrastructure. PaaS services can be as generalized as [Azure App Service](https://docs.microsoft.com/azure/app-service/), which is a robust web hosting platform similar to Microsoft Internet Information Services, or as specialized as [Azure Service Bus Messaging](https://docs.microsoft.com/azure/service-bus-messaging/), a reliable message broker. 

Many Azure PaaS offerings are similar to Service Bus Messaging in that they are "building blocks" that can be leveraged by any application, whether they are hosted in the Azure, on-premises, or with another cloud provider.  PaaS services like this can be pieced together in various combinations to support virtually any type of application.  Outsourcing pieces of your application to the cloud enables you to bootstrap development of your application quickly, since the functionality of things like authentication, message queuing, blob storage, and SQL or NoSQL databases can be integrated into your application as a dependency rather than new development. 

PaaS should be given serious consideration for greenfield development of new applications, since there is a considerable value proposition in terms of development time and ongoing maintenance, as well as cost.

The processes presented in this guide will assume the application is at least hosted in Azure App Service, but dependencies on "building block" services will be avoided.

### Software as a Service

Virtually everybody uses some type of **Software as a Service** (**SaaS**) application. SaaS is a subscription or ad-based model where software is run from the cloud, usually in a a browser. Office 365, Salesforce, Dropbox, Google Docs, and Gmail are all examples of SaaS. SaaS has no relevance to this guide.

## Conclusion

This guide will prepare you to build a continuous integration development lifecycle built around ASP.NET and Azure PaaS products.

## Additional reading

* [What is Cloud Computing?](https://azure.microsoft.com/overview/what-is-cloud-computing/)
* [Examples of Cloud Computing](https://azure.microsoft.com/overview/examples-of-cloud-computing/)
* [What is IaaS?](https://azure.microsoft.com/overview/what-is-iaas/)
* [What is PaaS?](https://azure.microsoft.com/overview/what-is-paas/)