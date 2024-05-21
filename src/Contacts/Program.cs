using Contacts.Api;
using Contacts.Application;
using Contacts.Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApi()
        .AddApplication()
        .AddPersistence();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
