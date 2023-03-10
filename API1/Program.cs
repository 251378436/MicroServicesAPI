using API1;
using API1.Constraints;
using API1.Converters;
using API1.Filters;
using API1.Services;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHealthChecks();

builder.Services.AddRouting(options =>
    options.ConstraintMap.Add("testId", typeof(TestIdConstraint)));

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

builder.Services.AddScoped<ICalculator, Calculator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SchemaFilter<ExampleSchemaFilter>();
});

builder.Services.AddHostedService<TimedHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHealthChecks("/healthz");
app.MapControllers();

app.Run();
