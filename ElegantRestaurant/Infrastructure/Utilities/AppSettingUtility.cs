
using Microsoft.Extensions.Configuration;

namespace Commons.Utilities
{
    public class AppSettingUtility
    {
        protected IConfigurationRoot Configuration { get; set; }

        public AppSettingUtility(bool reload = false)
        {
            Configuration = GetLocalAppSetting(reload);
        }

        public AppSettingUtility(string path, bool reload = false)
        {
            Configuration = GetLocalAppSetting(path, reload);
        }
        public AppSettingUtility(string path, string filename, bool required = true, bool reload = true)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(path)
                .AddJsonFile(filename, required, reload).Build();
        }
        public static IConfigurationRoot Get(string path, string filename, bool required = true, bool reload = true)
        {
            return new ConfigurationBuilder().SetBasePath(path)
                .AddJsonFile(filename, required, reload).Build();
            
        }
        public string GetDefaultConnectionString()
        {
            return Configuration.GetConnectionString("DefaultConnection");
        }

        public static IConfigurationRoot GetLocalAppSetting( bool reload = false)
        {
            return new ConfigurationBuilder().SetBasePath(PathUtility.GetPathByProcess())
                .AddJsonFile("appsettings.json", true, reload).Build();

        }
        public static IConfigurationRoot GetLocalAppSetting(string path = "", bool reload = false)
        {
            return new ConfigurationBuilder().SetBasePath(PathUtility.GetPathByProcess())
                .AddJsonFile(path + "appsettings.json", true, reload).Build();

        }
    }

       
}
  
