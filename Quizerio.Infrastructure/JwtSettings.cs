namespace Quizerio.Infrastructure
{
    public record JwtSettings
    {
        public JwtSettings() {}
        
        public JwtSettings(string key, string issuer, string audience)
        {
            Key = key;
            Issuer = issuer;
            Audience = audience;
        }

        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
    
    
}