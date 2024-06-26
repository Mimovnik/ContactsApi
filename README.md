# Contacts Api

## Prerequisites

- dotnet7

## Installation

```
git clone https://github.com/Mimovnik/ContactsApi
```

## Run

```
dotnet run --project src/Contacts
```

## Trust connection

Open this link in your browser and proceed to the website to trust this connection.
[localhost:7212](https://localhost:7212)

## Used frameworks

- EntityFramework
- Mapster
- ErrorOr
- MediatR
- FluentValidation

## Architecture

I was trying to structure the project with Clean Architecture principles.  
I used Command Query Responsibility Segragation (CQRS).
I split the project into layers, with individual directory for each: 
- Api (presentation layer)
- Application (command and query handling)
- Infrastructure (authentication and persistence)
- Domain (business logic)

## Link to front-end repo

[ContactsClient](https://github.com/Mimovnik/ContactsClient)
