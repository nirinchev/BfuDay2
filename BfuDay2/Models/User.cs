using System.ComponentModel.DataAnnotations;

namespace BfuDay2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}