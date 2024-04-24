using Domain.Entity;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
