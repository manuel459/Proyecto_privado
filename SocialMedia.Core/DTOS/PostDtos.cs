using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.DTOS
{
    public class PostDtos
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
