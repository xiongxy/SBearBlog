using System;

namespace SBear.Entities.BlogEntities
{
    public class BlogArticleEntity : BaseEntity
    {
        public String Title { get; set; }
        public String MarkDownContent { get; set; }
        public String HtmlContent { get; set; }
        public String TextConetent { get; set; }
        public String Label { get; set; }
        public int Views { get; set; }
        public long BlogArticleTypeId { get; set; }
        public BlogArticleTypeEntity BlogArticleType { get; set; }
    }
}
