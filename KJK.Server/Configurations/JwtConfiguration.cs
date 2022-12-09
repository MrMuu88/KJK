using NuGet.Packaging.Signing;

namespace KJK.Server.Configurations
{
    public class JwtConfiguration
    {
        public string Issuer { get;set;}
        public string Audience { get;set;}
        public string Key { get;set;}
        public int TokenLifeTime { get; set; }
    }
}
