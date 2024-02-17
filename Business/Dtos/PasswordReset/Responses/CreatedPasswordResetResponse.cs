namespace Business.Dtos.PasswordReset.Responses
{
    public class CreatedPasswordResetResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Code { get; set; }

    }
}
