# AWS LocalStack developing using .NET Core

## Setup
 use docker-compose by running the setup.cmd for Windows or setup.sh for Linux/MacOS:

```
cd build
./setup.cmd
```

The setup script will add the value in SSM after starting localstack, but you can also do that using this command:

```aws --endpoint-url=http://localhost:4583 ssm put-parameter --name "/demo/settings/intervalInSeconds" --type String --value "60" --overwrite --region "us-east-1"```

To query the value, use this command:

```aws ssm --endpoint-url=http://localhost:4583 get-parameter --name "/demo/settings/intervalInSeconds"```

## Tools:

[LocalStack](https://github.com/localstack/localstack)

[Commandeer](https://getcommandeer.com/)


## Overview

### Min.App.Core

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Min.App.Business

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Min.App.Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### Min.App.Web

The presentation layer is based on ASP.NET Core 5. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure.