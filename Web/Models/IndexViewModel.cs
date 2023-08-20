using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public sealed class IndexViewModel
    {
        public string? Username { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? ImagePreviewBase64 { get; set; }
    }
}
