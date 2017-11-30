using System;
using System.Collections.Generic;
using System.Text;
using SBear.Service.Blog.Dtos;

namespace SBear.Service.Blog.IBlogService
{
    public interface IBlogUserService
    {
        BlogUserDto CheckUser(string userName, string password);
        BlogUserDto GetUser(string userName);
        BlogUserDto Insert(string userName, string password);
    }
}
