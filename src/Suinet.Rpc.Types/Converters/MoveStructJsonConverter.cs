﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Suinet.Rpc.Types.MoveTypes;
using System;
using System.Collections.Generic;

namespace Suinet.Rpc.Types.Converters
{
    public class MoveStructJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(MoveStruct).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            MoveStruct moveStruct;

            if (jsonObject.Type == JTokenType.Array)
            {
                moveStruct = new ArrayMoveStruct
                {
                    Value = jsonObject.ToObject<List<MoveValue>>(serializer)
                };
            }
            else if (jsonObject.Property("fields") != null && jsonObject.Property("type") != null)
            {
                moveStruct = new ObjectMoveStruct
                {
                    Fields = jsonObject["fields"].ToObject<Dictionary<string, MoveValue>>(serializer),
                    Type = jsonObject["type"].ToString()
                };
            }
            else
            {
                moveStruct = new AdditionalPropertiesMoveStruct
                {
                    AdditionalProperties = jsonObject.ToObject<Dictionary<string, MoveValue>>(serializer)
                };
            }

            return moveStruct;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}
