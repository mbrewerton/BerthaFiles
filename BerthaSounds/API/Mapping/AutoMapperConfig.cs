using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace API.Mapping
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x => AddProfiles(Mapper.Configuration));
        }

        private static void AddProfiles(IConfiguration configuration)
        {
            var profiles = typeof (CouponDtoToCouponProfile).Assembly.GetTypes().Where(x => typeof (Profile).IsAssignableFrom(x));
            foreach (var profile in profiles)
            {
                configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
            }
        }
    }
}
