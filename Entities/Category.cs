using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Day11.Entities
{
    [Table("Category")]
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}