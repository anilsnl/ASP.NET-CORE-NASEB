using System;
using Microsoft.Extensions.Configuration;
using NASEB.Library.Helper.AppSettings;

namespace NASEB.Library.MVCWebUI.Infrastructure
{
    public class AppSettings:IAppSettings
    {
        private IConfiguration configuration;
        public AppSettings(IConfiguration _config)
        {
            configuration = _config;
        }

        public double DaylyDelayFine { get
            {
                return Convert.ToDouble(configuration["ApplicationSettings:DaylyDelayFine"].ToString());
            }
             }
    }
}
