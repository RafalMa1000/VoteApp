 # Task
The task is to create voting app (as per mock). User should be able to add candidates and voters and then select candidate & voter in order to cast a vote. FE part can be done in any way (web, desktop or even a console, functionality matters) - for BE devs FE part should contain functionalities as visible on mock - might look completely different though - for fullstack devs The two sections can be either on single page or separate ones. Important part is to make sure that both tables and dropdowns are always up to date - eg. when casting a vote the Votes counter should be updated and 'has voted' flag for a proper voter should be changed as well.

I assumed that voter can cast only one vote, but this requirement needs to be confirmed with the product owner :) I have added that functionality in order to show the behavior of fluent validation rules.
 
 # Technologies
ASP.NET Core 8
Entity Framework Core 8
Angular 15
MediatR
AutoMapper
FluentValidation
NUnit, FluentAssertions...

 # Clean Architecture Solution
Core is not dependent on data access and other infrastructure concerns so those dependencies are inverted.
Domain layer contains enterprise wide logic and types
Application layer contains business logic and types typically only be used within this system. This project implements CQRS (Command Query Responsibility Segregation), with each business use case represented by a single command or query.
Presentation depend on Core. WebUI is representing the Presentation layer. Voting is implemented as SPA
Infrastructure depend on Core. Layer contains classes for accessing external resources such as file systems, web services, database eg. SQL Server, and so on. These classes should be based on interfaces defined within the Application layer. In this project I am not using own repositories for simplicity. The DbContext is a unit of work and each DbSet is a repository. In other projects I was implemening own repositories: implementation in infrastructure layer (interface in application layer).
 
 # Tests
I have added only a few just for giving a sample how they can be implemented

 # Validations
I have assumed some rules but more requirements needs to be gathered... 

## Build

Run `dotnet build -tl` to build the solution.

## Run

To run the web application:

```bash
cd .\src\Web\
dotnet watch run
```

Navigate to https://localhost:5001. The application will automatically reload if you change any of the source files.

## Code Styles & Formatting

The template includes [EditorConfig](https://editorconfig.org/) support to help maintain consistent coding styles for multiple developers working on the same project across various editors and IDEs. The **.editorconfig** file defines the coding styles applicable to this solution.

## Code Scaffolding

The template includes support to scaffold new commands and queries.

Start in the `.\src\Application\` folder.

Create a new command:

```
dotnet new ca-usecase --name CreateTodoList --feature-name TodoLists --usecase-type command --return-type int
```

Create a new query:

```
dotnet new ca-usecase -n GetTodos -fn TodoLists -ut query -rt TodosVm
```

If you encounter the error *"No templates or subcommands found matching: 'ca-usecase'."*, install the template and try again:

```bash
dotnet new install Clean.Architecture.Solution.Template::8.0.2
```

## Test

The solution contains unit, integration, functional, and acceptance tests.

To run the unit, integration, and functional tests (excluding acceptance tests):
```bash
dotnet test --filter "FullyQualifiedName!~AcceptanceTests"
```

To run the acceptance tests, first start the application:

```bash
cd .\src\Web\
dotnet run
```

Then, in a new console, run the tests:
```bash
cd .\src\Web\
dotnet test
```

 # Template

The project was generated using the [Clean.Architecture.Solution.Template](https://github.com/jasontaylordev/Voting) version 8.0.2.
To learn more about the template go to the [project website](https://github.com/jasontaylordev/CleanArchitecture). Here you can find additional guidance, request new features, report a bug, and discuss the template with other users.
