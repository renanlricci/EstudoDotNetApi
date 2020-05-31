namespace DotNetApi.Domain.Queries.User
{
    public sealed class GetAllUserQueryResponse
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}