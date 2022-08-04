# Escopo 

# BoxApp for ASP.NET Core 3.1

Sigesp for ASP.NET Core is an open-source and cross-platform framework for building modern cloud based internet connected applications, such as web apps, IoT apps and mobile backends. Sigesp for ASP.NET Core apps can run on .NET Core or on the full .NET Framework. It was architected to provide an optimized development framework for apps that are deployed to the cloud or run on-premises. It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions. You can develop and run your Sigesp for ASP.NET Core apps cross-platform on Windows, Mac and Linux. [Learn more about ASP.NET Core](https://docs.microsoft.com/aspnet/core/).

## Get Started

Follow the **Getting Started** instructions in the Sigesp for ASP.NET Core **docs** folder or directly from the **ASP.NET Core 3.1** menu after launching the website locally.

Or use the following instructions to setup a local server running Sigesp for ASP.NET Core:

1. Download and install the **ASP.NET Core 3.1 SDK** here: https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.102-windows-x64-installer
    * You can verify the installation by opening a command line tool of your choice and running the following command: `dotnet --info`
    * If you get a message similar to: `dotnet is not recognized as an internal command`, then please try downloading the `32-bit` version of the ASP.NET Core 3.1 SDK
    * You can find it here: https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.102-windows-x86-installer
1. Download and install **SQL Server Express** here: https://go.microsoft.com/fwlink/?linkid=853017
    * Note: You can also install **LocalDB** as part of Visual Studio. During Visual Studio installation, select the **.NET desktop development** workload, which includes SQL Server Express LocalDB.
    * If you are going to SQL Express then the default connection string *value* in `appSettings.json` will need to be adjusted
    * The value and instructions are written in `Startup.cs` but also listed here for your convinience:
    * `"Server=localhost\\SQLEXPRESS;Database=aspnet-smartadmin;Trusted_Connection=True;MultipleActiveResultSets=true"`
1. Open a command prompt and ensure you are inside the directory containing the **ASP.NET Core 3.1 project sources** of Sigesp 4.0
    * This is the directory containing the `SigespCore.sln` file
1. Run the following commands (in order) using the command line tool of your choice:
    * `dotnet build`
    * `dotnet publish` *(optional for localhost only deployment)*
    * `dotnet run --project ./src/Sigesp.WebUI/Sigesp.WebUI.csproj`
1. Launch your favorite browser and enter the following URL: https://localhost:5001, and try to login using the provided credentials
    * You may get a page mentioning that: 'Applying the existing migrations may resolve this issue'
    * Go ahead and click on the blue `Apply Migrations` button
1. If you receive a message stating: 'Invalid login attempt' then go ahead and Register the user
    * The username and password should be prefilled for demo purposes

> Note: You might get a security warning when browsing to your website, as the default `localhost` server will typically not have a trusted **localhost** SSL certificate!

Also check out the [.NET Homepage](https://www.microsoft.com/net) for released versions of .NET, getting started guides, and learning resources.

## How to Engage, Contribute, and Give Feedback

Some of the best ways to contribute are to try things out, file issues, join in design conversations, and make pull-requests.

* Download our latest builds
* Follow along with the development of Sigesp for ASP.NET Core:
  * [Roadmap](https://support.gotbootstrap.com/t/asp-net-core): The schedule and milestone themes for Sigesp for ASP.NET Core.
* Check out the [contributing](CONTRIBUTING.md) page to see the best places to log issues and start discussions.

## Reporting security issues and bugs

Security issues and bugs should be reported privately, via email, to Sigesp Security (SAC) at <secure@walapa.nl>. You should receive a response within 72 hours. If for some reason you do not, please follow up via email to ensure we received your original message.

## Code of conduct

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).  For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [smartadmin-next@walapa.nl](mailto:smartadmin-next@walapa.nl) with any additional questions or comments.

[![.NET Foundation](https://img.shields.io/badge/.NET%20Foundation-blueviolet.svg)](https://dotnetfoundation.org/projects/aspnet-api-versioning)
[![MIT License](https://img.shields.io/github/license/dotnet/aspnet-api-versioning?color=%230b0&style=flat-square)](https://github.com/dotnet/aspnet-api-versioning/blob/main/LICENSE.txt)
[![Build Status](https://dev.azure.com/aspnet-api-versioning/build/_apis/build/status/dotnet.aspnet-api-versioning.old?branchName=ms)](https://dev.azure.com/aspnet-api-versioning/build/_build/latest?definitionId=3&branchName=ms)

| :mega: Check out the [announcement](../../discussions/807) regarding upcoming changes |
|-|

# ASP.NET API Versioning

ASP.NET API versioning gives you a powerful, but easy-to-use method for adding API versioning semantics to your new and existing REST services built with ASP.NET. The API versioning extensions define simple metadata attributes and conventions that you use to describe which API versions are implemented by your services. You don't need to learn any new routing concepts or change the way you implement your services in ASP.NET today.

The default API versioning configuration is compliant with the [versioning semantics](https://github.com/Microsoft/api-guidelines/blob/master/Guidelines.md#12-versioning) outlined by the [Microsoft REST Guidelines](https://github.com/Microsoft/api-guidelines). There are also a number of customization and extension points available to support transitioning services that may not have supported API versioning in the past or supported API versioning with semantics that are different from the [Microsoft REST versioning guidelines](https://github.com/Microsoft/api-guidelines/blob/master/Guidelines.md#12-versioning).

The supported flavors of ASP.NET are:

* **ASP.NET Web API**
  <div>Adds service API versioning to your Web API applications</div>

  [![NuGet Package](https://img.shields.io/nuget/v/Microsoft.AspNet.WebApi.Versioning.svg)](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Versioning)
  [![NuGet Downloads](https://img.shields.io/nuget/dt/Microsoft.AspNet.WebApi.Versioning.svg?color=green)](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Versioning)
  [![Quick Start](https://img.shields.io/badge/quick-start-9B6CD1)](../../wiki/New-Services-Quick-Start#aspnet-web-api)
  [![Examples](https://img.shields.io/badge/example-code-2B91AF)](../../tree/master/samples/webapi)

* **ASP.NET Web API and OData**
  <div>Adds service API versioning to your Web API applications using OData v4.0</div>

  [![NuGet Package](https://img.shields.io/nuget/v/Microsoft.AspNet.OData.Versioning.svg)](https://www.nuget.org/packages/Microsoft.AspNet.OData.Versioning)
  [![NuGet Downloads](https://img.shields.io/nuget/dt/Microsoft.AspNet.OData.Versioning.svg?color=green)](https://www.nuget.org/packages/Microsoft.AspNet.OData.Versioning)
  [![Quick Start](https://img.shields.io/badge/quick-start-9B6CD1)](../../wiki/New-Services-Quick-Start#aspnet-web-api-with-odata-v40)
  [![Examples](https://img.shields.io/badge/example-code-2B91AF)](../../tree/master/samples/webapi)

* **ASP.NET Core**
  <div>Adds service API versioning to your ASP.NET Core applications</div>

  [![NuGet Package](https://img.shields.io/nuget/v/Microsoft.AspNetCore.Mvc.Versioning.svg)](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Versioning)
  [![NuGet Downloads](https://img.shields.io/nuget/dt/Microsoft.AspNetCore.Mvc.Versioning.svg?color=green)](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Versioning)
  [![Quick Start](https://img.shields.io/badge/quick-start-9B6CD1)](../../wiki/New-Services-Quick-Start#aspnet-core)
  [![Examples](https://img.shields.io/badge/example-code-2B91AF)](../../tree/master/samples/aspnetcore)
  
* **ASP.NET Core and OData**
  <div>Adds API versioning to your ASP.NET Core applications using OData v4.0</div>

  [![NuGet Package](https://img.shields.io/nuget/v/Microsoft.AspNetCore.OData.Versioning.svg)](https://www.nuget.org/packages/Microsoft.AspNetCore.OData.Versioning)
  [![NuGet Downloads](https://img.shields.io/nuget/dt/Microsoft.AspNetCore.OData.Versioning.svg?color=green)](https://www.nuget.org/packages/Microsoft.AspNetCore.OData.Versioning)
  [![Quick Start](https://img.shields.io/badge/quick-start-9B6CD1)](../../wiki/New-Services-Quick-Start#aspnet-core-with-odata-v40)
  [![Examples](https://img.shields.io/badge/example-code-2B91AF)](../../tree/master/samples/aspnetcore)

This is also the home of the ASP.NET API versioning API explorers that you can use to easily document your REST APIs with Swagger:

* **ASP.NET Web API Versioned API Explorer**
  <div>Replaces the default API explorer in your Web API applications</div>

  [![NuGet Package](https://img.shields.io/nuget/v/Microsoft.AspNet.WebApi.Versioning.ApiExplorer.svg)](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Versioning.ApiExplorer)
  [![NuGet Downloads](https://img.shields.io/nuget/dt/Microsoft.AspNet.WebApi.Versioning.ApiExplorer.svg?color=green)](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Versioning.ApiExplorer)
  [![Quick Start](https://img.shields.io/badge/quick-start-9B6CD1)](../../wiki/API-Documentation#aspnet-web-api)
  [![Examples](https://img.shields.io/badge/example-code-2B91AF)](../../tree/master/samples/webapi/SwaggerWebApiSample)

* **ASP.NET Web API with OData API Explorer**
  <div>Adds an API explorer to your Web API applications using OData v4.0</div>

  [![NuGet Package](https://img.shields.io/nuget/v/Microsoft.AspNet.OData.Versioning.ApiExplorer.svg)](https://www.nuget.org/packages/Microsoft.AspNet.OData.Versioning.ApiExplorer)
  [![NuGet Downloads](https://img.shields.io/nuget/dt/Microsoft.AspNet.OData.Versioning.ApiExplorer.svg?color=green)](https://www.nuget.org/packages/Microsoft.AspNet.OData.Versioning.ApiExplorer)
  [![Quick Start](https://img.shields.io/badge/quick-start-9B6CD1)](../../wiki/API-Documentation#aspnet-web-api-with-odata)
  [![Examples](https://img.shields.io/badge/example-code-2B91AF)](../../tree/master/samples/webapi/SwaggerODataWebApiSample)

* **ASP.NET Core Versioned API Explorer**
  <div>Adds additional API explorer support to your ASP.NET Core applications</div>

  [![NuGet Package](https://img.shields.io/nuget/v/Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer.svg)](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer)
  [![NuGet Downloads](https://img.shields.io/nuget/dt/Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer.svg?color=green)](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer)
  [![Quick Start](https://img.shields.io/badge/quick-start-9B6CD1)](../../wiki/API-Documentation#aspnet-core)
  [![Examples](https://img.shields.io/badge/example-code-2B91AF)](../../tree/master/samples/aspnetcore/SwaggerSample)

* **ASP.NET Core with OData API Explorer**
  <div>Adds additional API explorer support to your ASP.NET Core applications using OData v4.0</div>

  [![NuGet Package](https://img.shields.io/nuget/v/Microsoft.AspNetCore.OData.Versioning.ApiExplorer.svg)](https://www.nuget.org/packages/Microsoft.AspNetCore.OData.Versioning.ApiExplorer)
  [![NuGet Downloads](https://img.shields.io/nuget/dt/Microsoft.AspNetCore.OData.Versioning.ApiExplorer.svg?color=green)](https://www.nuget.org/packages/Microsoft.AspNetCore.OData.Versioning.ApiExplorer)
  [![Quick Start](https://img.shields.io/badge/quick-start-9B6CD1)](../../wiki/API-Documentation#aspnet-core-with-odata)
  [![Examples](https://img.shields.io/badge/example-code-2B91AF)](../../tree/master/samples/aspnetcore/SwaggerODataSample)

You can find additional samples, documentation, and getting started instructions in the [wiki](../../wiki).

## Discussion

Have a general question, suggestion, or other feedback? Check out how you can [contribute](CONTRIBUTING.md).

## Reporting security issues and bugs

Security issues and bugs should be reported privately, via email, to the Microsoft Security Response Center (MSRC) [secure@microsoft.com](mailto:secure@microsoft.com). You should receive a response within 24 hours. If for some reason you do not, please follow up via email to ensure we received your original message. Further information, including the MSRC PGP key, can be found in the [Security TechCenter](https://technet.microsoft.com/en-us/security/ff852094.aspx).

## Code of conduct

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).  For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

----
> If you are an existing user, please makes sure you review the [release notes](../../releases) between all major and minor package releases.