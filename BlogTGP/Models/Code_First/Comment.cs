﻿using System;

namespace BlogTGP.Models
{
    public class Comment
    {
        public int id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }
        public string Body { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        
        public virtual Post Post { get; set; }
        public virtual ApplicationUser Author { get; set; }

    }
}