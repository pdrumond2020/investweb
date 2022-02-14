namespace Invest.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
        public bool IsAuthorised { get; set; }
    }
}