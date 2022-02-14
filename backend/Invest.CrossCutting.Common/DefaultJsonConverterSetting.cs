using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Invest.CrossCutting.Common
{
    public static class DefaultJsonConverterSetting
    {
        private static readonly List<JsonConverter> _converters = new() { new StringEnumConverter() };
        private static readonly JsonSerializerSettings _settings = ConfigureSettings(new JsonSerializerSettings());

        public static JsonSerializerSettings Settings => _settings;

        public static void AddConverter(JsonConverter converter)
        {
            _settings.Converters.Add(converter);
        }

        private static JsonSerializerSettings ConfigureSettings(JsonSerializerSettings settings)
        {
            settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
            settings.DateParseHandling = DateParseHandling.None;
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Converters = _converters;
            settings.ContractResolver = new DefaultContractResolver() { NamingStrategy = new CamelCaseNamingStrategy() };

            return settings;
        }
    }
}