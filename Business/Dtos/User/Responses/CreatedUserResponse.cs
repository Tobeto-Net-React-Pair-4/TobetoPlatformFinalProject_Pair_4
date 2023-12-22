namespace Business.Dtos.User.Responses
{
    public class CreatedUserResponse
    {
        public Guid Id { get; set; }
        public Guid AppealId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}