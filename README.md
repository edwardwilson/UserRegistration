# User Registration

A simple registration application showing ASP.NET Core features and best practices. Services are designed with interfaces and test ability in mind. Keeping data access out of any business servies and allowing these to be mocked for testing.

More testing is needed; as the unit test coverage is thin; due to business logic being placecd into MVC model validators this has been hindered due to some odd behavour when testing the code and incorrect states where reported.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

```
- MSSQl
- DOTNET CORE 2.0
```

### Run locally
When started the application will look for a database using the connection string in the application settings. If none is found the set up script will be ran creating the required database, tables and indexes. This script can be ran manually if needed and can be found in [Initialize.sql](https://github.com/edwardwilson/UserRegistration/blob/master/src/UserRegistration/Sql/Initialize.sql) 

To run locally open a command prompt within the solution folder and run the following:

```
dotnet restore
dotnet run
```

## Running the tests
To run the unit tests open a command prompt within the solution folder and run the following
```
dotnet test
```

## Built With

* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/) - The web framework used
* [MSSQL](https://www.microsoft.com/en-gb/sql-server/) - Database
* [Serilog](https://serilog.net/) - Logging framework
* [Bootstrap](https://getbootstrap.net/) - CSS framework

## Authors

* [**Edward Wilson**](https://github.com/edwardwilson) - *Initial work*

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Project Information
## Database
The database is configured to use an identity column. The size of the columns are configured to reduce database size, with a max size of password at 64 characters and email address set at 254 which this is the maximum valid address; as described in [RFC3696 Errata ID 1690](https://www.rfc-editor.org/errata_search.php?eid=1690).

An index has been added to email address to aid in searches; this is a unique constraint which keeps data integrity. 

### Password Protection
The application uses a hashing algorithm to secure the passwords of users. SHA-256 is used with a 10000 ineration count; this give a very strong and non decryptable hash whih also is combine with a salt during the hash.

Further protect in a deployed environment can be made by restricting database access and user permissions.

A requirement of password complexity is that a password must be at least 4 characters, no more than 8 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit. More can be read about passowrd standards at:
 - https://blog.samanage.com/it-service-management/what-makes-for-a-good-password-policy/
 - https://technet.microsoft.com/en-us/library/ff741764.aspx

### Validation
A remote validation has been created to give users an near instant feedback on duplicate emails; where an address is already registers as they must be unique.

There appears to be some issues with the built in mvc model state validation which is giving false positives when the model is in fact invalid. More needs to be investigated into this.

