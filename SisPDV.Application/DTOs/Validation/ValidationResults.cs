namespace SisPDV.Application.DTOs.Validation
{
    public class ValidationResults
    {
        public bool IsValid { get; set; } = false;
        public List<string> Errors { get; set; } = new();
    }
}
