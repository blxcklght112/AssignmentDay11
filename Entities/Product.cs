using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Day11.Entities
{
    [Table("Product")]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Manufacture { get; set; }

        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
    }
}