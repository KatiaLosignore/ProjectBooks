using Microsoft.EntityFrameworkCore;
using ProjectBooks.Data;
using ProjectBooks.Repo;
using ProjectBooks.Service;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://example.com",
                                              "http://www.contoso.com");
                      });
});


//builder.Services.AddCors(o => // https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-7.0
//{
//    o.AddDefaultPolicy(policy =>
//    {
//        policy.WithMethods("POST", "PUT", "GET", "OPTIONS");
//        policy.WithOrigins("*");
//        policy.AllowAnyOrigin();
//        policy.AllowAnyHeader();
//    });
//});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IBookservice, Bookservice>();
builder.Services.AddTransient<IBookrepository, Bookrepository>();
builder.Services.AddTransient<ICategoryrepository, Categoryrepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
