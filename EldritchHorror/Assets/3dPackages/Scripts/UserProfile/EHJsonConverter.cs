using Newtonsoft.Json;
using System;

namespace EldrtichHorror.UserProfile
{
    public class EHJsonConverter : IJsonConverter
    {
        protected readonly JsonSerializerSettings _jsonSettings;

        public EHJsonConverter() : this(Formatting.None)
        {
        }

        public EHJsonConverter(Formatting formatting = Formatting.None)
        {
            _jsonSettings = new JsonSerializerSettings
                            {
                                Formatting       = formatting,
                                ContractResolver = new EnumToIntKeyContractResolver(),
                            };
        }

        public object Deserialize(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type, _jsonSettings);
        }

        public string SerializeObject<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSettings);
        }

        public T Deserialize<T>(string containerJsonString)
        {
            return JsonConvert.DeserializeObject<T>(containerJsonString, _jsonSettings);
        }
    }
}