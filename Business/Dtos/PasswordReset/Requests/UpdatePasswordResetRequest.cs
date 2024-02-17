namespace Business.Dtos.PasswordReset.Requests
{
    public class UpdatePasswordResetRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Code { get; set; }

    }
}
