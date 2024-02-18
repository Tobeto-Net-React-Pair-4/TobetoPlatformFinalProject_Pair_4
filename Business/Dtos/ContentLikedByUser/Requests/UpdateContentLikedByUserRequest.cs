namespace Business.Dtos.ContentLikedByUser.Requests
{
    public class UpdateContentLikedByUserRequest
    {
        public Guid UserId { get; set; }
        public Guid ContentId { get; set; }
    }
}
