using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddOData(options =>
    {
        var modelBuilder = new ODataConventionModelBuilder();
        modelBuilder.EntitySet<Contact>("Contacts");
        options.AddRouteComponents(modelBuilder.GetEdmModel(), new DefaultODataBatchHandler());
    });

var app = builder.Build();

app.UseODataBatching().UseRouting().UseEndpoints(routeBuilder => routeBuilder.MapControllers());

app.Run();

public class Contact
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

[EnableQuery]
public class Contacts : ODataController
{
    public IQueryable<Contact> Get()
    {
        return new[] { new Contact() }.AsQueryable();
    }
    
    public Contact Get(int key)
    {
        return new Contact { Id = key };
    }
    
    public CreatedODataResult<Contact> Post(Contact entity)
    {
        return Created(entity);
    }
}