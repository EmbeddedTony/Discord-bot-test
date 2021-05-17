using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Newtonsoft.Json;

namespace Discord_bot_test
{
    struct ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        
        [JsonProperty("prefix")]

        public string Prefix { get; private set; }
    }
}
