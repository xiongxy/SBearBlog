﻿using System;

namespace SBear.Entities.BlogEntities
{
    public class BlogArticleEntity : BaseEntity
    {
        public String Title { get; set; }
        public String MarkDownContent { get; set; }
        public String HTMLContent { get; set; }
        public String Label { get; set; }
    }
}
