using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
});


// contexts
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

var app = builder.Build();
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/api/products", async (DataContext context) => await context.Products.ToListAsync())
.WithName("Products")
.WithOpenApi();

app.Run();
