namespace Business.Dtos.PasswordReset.Requests
{
    public class CreatePasswordResetRequest
    {
        public Guid UserId { get; set; }
        public string Code { get; set; }

    }
}
