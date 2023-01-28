# Jotform.NET

> .NET 7 async library for the Jotform API, using best practices and great test coverage

[![](https://img.shields.io/nuget/v/Jotform.NET.svg?label=nuget)](https://www.nuget.org/packages/Jotform.NET)
[![](https://img.shields.io/nuget/dt/Jotform.NET.svg?label=downloads)](https://www.nuget.org/packages/Jotform.NET)


## Installation

Install the package from NuGet

    Install-Package Jotform.NET



## Usage

Create a new JotformClient

```csharp
var jotform = new JotformClient("myapikey");

// For enterprise users
var jotform = new JotformClient("myapikey", "mysubdomain");
```

Basic usage

```csharp
var forms = await jotform.GetUserFormsAsync();
```

## Documentation

The documentation is available at https://api.jotform.com/docs/

Minor API changes have been made to use stronger typing, follow the method parameters for self explanatory usage.

## TODO

 - [ ] There is a property explorer, make sure it is up to date with the API
https://api.jotform.com/docs/properties/index.php
 - [ ] Add non-read operation tests
 - [ ] Question Types & response types should use different objects


