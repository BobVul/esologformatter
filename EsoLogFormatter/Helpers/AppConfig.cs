using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;

namespace EsoLogFormatter.Helpers
{
    class AppConfig
    {
        public ChannelMapping DefaultChannels { get; set; }
        public TemplateMapping TypeTemplates { get; set; }

        public class ChannelMapping : Dictionary<int, string> { }
        public class TemplateMapping : Dictionary<string, string> { }

        public static AppConfig Config => config.Value;
        private static Lazy<AppConfig> config = new Lazy<AppConfig>(() =>
        {
            using var reader = new StreamReader("app.yaml");
            var deserialiser = new DeserializerBuilder()
                .Build();
            return deserialiser.Deserialize<AppConfig>(reader);
        });
    }
}
