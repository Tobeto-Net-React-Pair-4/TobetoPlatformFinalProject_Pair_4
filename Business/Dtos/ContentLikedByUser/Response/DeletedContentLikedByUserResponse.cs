namespace Business.Dtos.ContentLikedByUser.Response
{
    public class DeletedContentLikedByUserResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ContentId { get; set; }
    }

}
