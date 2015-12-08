using System;
using System.Configuration;

namespace ServiceRegister.AngularApplication.Configuration
{
    public class ServiceRegisterApiConfiguration : ConfigurationSection
    {
        private static readonly ServiceRegisterApiConfiguration SettingsInstance =
            ConfigurationManager.GetSection("serviceRegisterApi") as ServiceRegisterApiConfiguration;

        public static ServiceRegisterApiConfiguration Settings
        {
            get { return SettingsInstance; }
        }

        [ConfigurationProperty("baseUrl", IsRequired = true)]
        public Uri BaseUrl
        {
            get { return (Uri) this["baseUrl"]; }
            set { this["baseUrl"] = value; }
        }

        [ConfigurationProperty("maxOntologyTermSearchResults")]
        public int MaxOntologyTermSearchResults
        {
            get { return (int)this["maxOntologyTermSearchResults"]; }
            set { this["maxOntologyTermSearchResults"] = value; }
        }

        protected override void PostDeserialize()
        {
            if (!(this["baseUrl"] is Uri))
            {
                throw new ConfigurationErrorsException("Base url is required.");
            }
        }
    }
}