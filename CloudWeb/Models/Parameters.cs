using Microsoft.AspNetCore.Http;
using System.Drawing;

namespace CloudWeb.Models
{
    public class Parameters
    {
        public IFormFile File { get; set; }
        public Color[] Colors  { get; set; }
        public int MinFont { get; set; }
        public int MaxFont { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string FontName { get; set; }
    }
}
