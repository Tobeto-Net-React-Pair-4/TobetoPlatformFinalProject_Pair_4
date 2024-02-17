namespace Business.Dtos.ContentLikedByUser.Requests
{
    public class CreateContentLikedByUserRequest
    {
        public Guid UserId { get; set; }
        public Guid ContentId { get; set; }
    }
}
