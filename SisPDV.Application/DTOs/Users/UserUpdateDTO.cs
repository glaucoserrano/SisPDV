namespace SisPDV.Application.DTOs.Users
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Login { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
