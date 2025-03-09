using System;
using System.Collections.Generic;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using VDJPlugin.Configuration;

namespace VDJPlugin
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public override string Name => "VDJ Plugin";
        public override Guid Id => Guid.Parse("b0daa5f4-2c6a-4c9e-a9c5-e0d67a1c3e93");
        public override string Description => "Intégration de Jellyseer pour les requêtes de médias";

        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer) 
            : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
        }

        public static Plugin Instance { get; private set; }

        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new[]
            {
                new PluginPageInfo
                {
                    Name = "request",
                    EmbeddedResourcePath = GetType().Namespace + ".Pages.RequestPage.html",
                    EnableInMainMenu = true,
                    MenuIcon = "search",
                    MenuSection = "users"
                }
            };
        }
    }
} 