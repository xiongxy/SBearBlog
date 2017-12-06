using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace SBear.Framework.Account
{
    public static class UserRuntimeContext
    {
        public static UserRuntimeInfo CurrentUser
        {
            get
            {
                if (SBearHttpContext.Current.Session.GetString("LoginMessage") == null)
                {
                    return null;
                }
                else
                {
                    return JsonConvert.DeserializeObject<UserRuntimeInfo>(SBearHttpContext.Current.Session.GetString("LoginMessage"));
                }
            }
            set
            {
                SBearHttpContext.Current.Session.SetString("LoginMessage", JsonConvert.SerializeObject(value as UserRuntimeInfo));
            }
        }
        public static bool CheckUserLogin()
        {
            return CurrentUser != null;
        }
    }

    public class UserRuntimeInfo
    {
        public String NickName { get; set; }
        public String UserName { get; set; }
    }
}
