namespace Invidux_Domain.Models
{
    public class TokenImage: BaseToken
    {
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
    }
}
