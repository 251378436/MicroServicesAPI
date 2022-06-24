using API1.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API1.Filters
{
    public class ExampleSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            //if (context.Type == typeof(RequestModel))
            //{
            //    schema.Example = new OpenApiObject()
            //    {
            //        ["firstName"] = new OpenApiInteger(1),
            //        ["lastName"] = new OpenApiString("Doe"),
            //    };
            //}
        }
    }
}
