using API1.Converters;
using API1.Filters;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers()
    .AddJsonOptions(options =>
{
    //JsonOptions
    //options.JsonSerializerOptions.Converters.Add(new CustomDateTimeConverter());
});
//.AddNewtonsoftJson();
//builder.Services.AddSwaggerGenNewtonsoftSupport();

//builder.Services.Configure<JsonOptions>(options =>
//{
//    //options.SerializerOptions.Converters.Add(new CustomDateTimeConverter());
//    options.SerializerOptions.PropertyNameCaseInsensitive = false;
//    options.SerializerOptions.PropertyNamingPolicy = null;
//    options.SerializerOptions.WriteIndented = true;
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SchemaFilter<ExampleSchemaFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
