namespace backend.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }

        public string? Role { get; set; }

        public int? HuurbeheederId { get; set; }
    }
}
