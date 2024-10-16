﻿using GameEngine;
using Newtonsoft.Json;


namespace SaveLoad
{
    public struct ResourceData
    {
        [JsonProperty]
        public string Id { get; private set; }

        [JsonProperty]
        public int Amount { get; private set; }

        public ResourceData(Resource resource)
        {
            Id = resource.ID;
            Amount = resource.Amount;
        }

    }
}
