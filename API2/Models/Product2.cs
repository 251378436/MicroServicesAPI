using Amazon.DynamoDBv2.DataModel;

namespace API2.Models
{
    [DynamoDBTable("products2")]
    public class Product2
    {
        [DynamoDBHashKey("messageId")]
        public string? MessageId { get; set; }

        [DynamoDBRangeKey("received")]
        public string? Received { get; set; }

        [DynamoDBProperty("description")]
        public string? Description { get; set; }

        [DynamoDBProperty("price")]
        public decimal? Price { get; set; }

        [DynamoDBProperty("message")]
        public string? Message { get; set; }
    }
}
