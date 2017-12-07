using SBear.Web.ViewComponents.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBear.Service.Blog.Dtos;

namespace SBear.Web.ViewModels
{
    public class CardViewModel
    {
        public CardAciotnTypeEnum CardAciotnType { get; set; }
        public long ArticleIdentityId { get; set; }
        public int SearchCount { get; set; }
        public BlogArticleTypeDto Catgory { get; set; }
    }
}
