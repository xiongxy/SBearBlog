using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SBear.Service.Blog;

namespace SBear.Service
{
    public class SBearMapperInitialize
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                BlogMapperInit.Init(config);
            });

        }
    }
}
