using Core.Entities;
using Core.Entities.Concrete;


namespace Entities.Concretes
{
    public class Certificate : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
    }
}
