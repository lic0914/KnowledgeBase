using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kb.Web.KBMapper
{
    public class KBMapper
    {
        public static void Initialize()
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.AddProfile()
            //});
        }
        public static Taget Map<TScource,Taget>(TScource scource)
        {
           return Mapper.Map<TScource, Taget>(scource);
        }
    }
}
