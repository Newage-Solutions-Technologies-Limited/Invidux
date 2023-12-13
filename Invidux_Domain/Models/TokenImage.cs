namespace Invidux_Domain.Models
{
    public class TokenImage: BaseToken
    {
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
    }
}
