# Copilot Instructions

This project is a web application that allows users to create and manage salary increase calculation within scenarios. The application is built using .Net C# and Blazor, follows architectural approach as Modular Monolith. I chose this approach if we need to move any module to a microservice. Any module can use its own design pattern. For example, scenario module uses Vertical slices. Currently every module can use its own choice as a database but for now it uses Postgres as the database.

Modules have to interact to other modules by contracts rather than direct dependency. To keep them away dependant to each other, endpoint classes access modifiers are internal.

Endpoints uses FastEndpoints library to follow minimal api approach.

Tests are written per module for both unit and integration. Integration tests use Testcontainers library to make use of a real database for realistic results. The unit tests use in memory database.

Blazor project is inside the UI folder.

Common build props are in Directory.Build.props file.

This application makes use of dotnet aspire.
