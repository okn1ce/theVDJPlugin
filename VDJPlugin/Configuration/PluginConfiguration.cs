using MediaBrowser.Model.Plugins;

namespace VDJPlugin.Configuration
{
    public class PluginConfiguration : BasePluginConfiguration
    {
        public string JellyseerApiUrl { get; set; }
        public string JellyseerApiKey { get; set; }

        public PluginConfiguration()
        {
            JellyseerApiUrl = "http://localhost:5055/api/v1";
            JellyseerApiKey = "";
        }
    }
} 