﻿using MongoDB.Bson.Serialization.Attributes;

namespace Api.Models
{
    public class Counter
    {
        [BsonId]
        public string Key { get; set; }

        public int Seq { get; set; }
    }
}
