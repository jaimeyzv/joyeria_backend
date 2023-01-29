namespace Joyeria.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public int UserTypeId { get; set; }
        public int DocumentTypeId { get; set; }

    }
}
