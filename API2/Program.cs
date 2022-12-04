using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using API2.Configuration;
using API2.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Api2Settings>(builder.Configuration.GetSection("api2Settings"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CookieFilter>();

//// Get the AWS profile information from configuration providers
//AWSOptions awsOptions = builder.Configuration.GetAWSOptions();

//// Configure AWS service clients to use these credentials
//builder.Services.AddDefaultAWSOptions(awsOptions);

//builder.Services.AddAWSService<IAmazonDynamoDB>();

builder.Services.AddSingleton<IAmazonDynamoDB>(sp =>
{
    var clientConfig = new AmazonDynamoDBConfig
    {
        ServiceURL = "https://dynamodb.ap-northeast-1.amazonaws.com"
    };

    var awsCredentials = new BasicAWSCredentials("AKIAVZPMOTO2LG7DIG7K", "JAKR6m4az3cAcmq6iMKpfZGh2ni3jTVpNCohUWmo");

    AmazonDynamoDBClient client = new AmazonDynamoDBClient(awsCredentials, clientConfig);

    return client;
});
builder.Services.AddScoped<IDynamoDBContext, DynamoDBContext>();

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
