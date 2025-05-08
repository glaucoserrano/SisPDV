namespace SisPDV.Application.DTOs.Menus
{
    public class MenuDTO
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? FormName { get; set; } = string.Empty;
        public int Order { get; set; }
    }
}
