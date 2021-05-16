#nullable disable

namespace CrudService.Models
{
    public partial class Team
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}
