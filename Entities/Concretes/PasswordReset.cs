using Core.Entities.Concrete;

namespace Entities.Concretes
{
    public class PasswordReset : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string Code { get; set; }
        public User User { get; set; }
    }
}