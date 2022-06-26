using API1.Attributes;
using API1.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API1.Models
{
    public class RequestModel
    {
        public string? test1;

        private string? test2 { get; set; }

        //[JsonIgnore]
        [SwaggerDefaultValue("aaaaaaaaaaaa")]
        [Required]
        [MinLength(3)]
        public string? RequestId { get; set; }

        //[Required]
        [DataType(DataType.Date)]
        //[DataType("yyyy-MM-dd")]
        //[SwaggerDefaultValue("bbbbbbbbbbbbb")]
        //[CustomAdmissionDate]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? BirthDay { get; set; }
    }
}
