# Today List

Simple "to do" list for organizing your day.


## Backend Technologies

* .NET Core 3.1
* ASP .NET Core 3.1
* Entity Framework Core 3.1

## Frontend Technologies

* React 16.12
* Redux 4.0

## Database Migrations

To create new migration:
`dotnet ef migrations add "MigrationName" --project src\TodayList.Infrastructure --startup-project src\TodayList.Api`

To apply latest migration to database:
`dotnet ef database update --project src\TodayList.Infrastructure --startup-project src\TodayList.Api`

## License

This project is licensed with the [MIT license](LICENSE).