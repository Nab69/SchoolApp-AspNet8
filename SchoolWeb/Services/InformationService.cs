namespace SchoolWeb.Services
{
    public class InformationService : IInformationService
    {
        private IWebHostEnvironment environment;

        public InformationService(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public string GetApplicationName()
        {
            return this.environment.ApplicationName;
        }

        public string GetEnvironmentName()
        {
            return this.environment.EnvironmentName;
        }
    }
}
