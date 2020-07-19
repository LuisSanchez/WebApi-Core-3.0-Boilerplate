# WebApi-Core-3.0-Boilerplate

Simple C# webapi boilerplate with sql server connection.

A simple project that combines the basic of web api core 3.0 to connect with a class library project that connects to a sql server data base example. Using EF Core, migrations, code first, DI.

Instead of having the webapi to connect to the database, the connection string is passed to the class library using DI.

This boilerplate uses the case of a simple address service that reads from a database.

Check startup.cs:

## Usage

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
    services.AddControllers();

    // to access the context 
    services.AddHttpContextAccessor();

    // Register the class that reads the DB into the DI framework
    services.AddTransient<IAddressBusiness, AddressBusiness>();
}
```


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT License](https://choosealicense.com/licenses/mit/)

