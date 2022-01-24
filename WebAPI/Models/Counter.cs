using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Counter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Value { get; set; }
    }
}
