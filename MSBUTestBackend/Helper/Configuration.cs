namespace MSBUTestBackend.Helper
{
    public class Configuration
    {
        public IConfiguration Config { get; }
        public string ConString = string.Empty;

        public Configuration(IConfiguration _Config)
        {
            Config = _Config;
            this.setConnectionString();
            this.ConString = this.getConnectionString();
        }

        public void setConnectionString()
        {
            this.ConString = Config["ConnectionStrings:DefaultConnection"];
        }
        public string getConnectionString() 
        {
            return this.ConString;
        }
    }
}
