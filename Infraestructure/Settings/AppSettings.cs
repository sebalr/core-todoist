using System;
namespace todoist.Infraestructure.Settings
{
    public interface IAppSettings
    {
        AuthSettings AuthSettings { get; }
        DbSettings DbSettings { get; }
    }

    public class AppSettings : IAppSettings
    {
        public AuthSettings AuthSettings { get; set; }
        public DbSettings DbSettings { get; set; }
    }

    public class AuthSettings
    {
        public string SecretKeyBase64 { get; set; }

        public byte[] SecretKey
        {
            get
            {
                return Convert.FromBase64String(SecretKeyBase64);
            }
        }
    }

    public class DbSettings
    {
        public string ConnectionString { get; set; }
    }
}