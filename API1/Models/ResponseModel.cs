using API1.Attributes;
using API1.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API1.Models
{
    public class ResponseModel
    {
        public string? test1;

        private string? test2 { get; set; }

        //[JsonIgnore]
        [SwaggerDefaultValue("aaaaaaaaaaaa")]
        public string? RequestId { get; set; }

        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        //[DataType("yyyy-MM-dd")]
        [SwaggerDefaultValue("bbbbbbbbbbbbb")]
        //[JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? BirthDay { get; set; }
    }
}
