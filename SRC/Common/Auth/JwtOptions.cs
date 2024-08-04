namespace Auth
{
    public class JwtOptions
    {
        public  string? SecretKey { get; set; }
        public int ExpireMinutes { get; set; }
        public string? Issuer { get; set; }
    } 
}
