using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using DSharpPlus.CommandsNext.Attributes;

namespace Discord_bot_test
{
    class Bot
    {

        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }


        public async Task RunAsync()
        {

            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var ConfigJson = JsonConvert.DeserializeObject<ConfigJson>(json);


            var config = new DiscordConfiguration
            {
                Token = ConfigJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
              // MinimumLogLevel = Log,
                //useInternal = true


            };

            Client = new DiscordClient(config);

             //Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new String[] { ConfigJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true,
                DmHelp = true,
                
                
                
            };

            // Register Commands Below

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<FunCommands>();

            await Client.ConnectAsync();

            await Task.Delay(-1);

        }

        private Task OnClientReady(ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }      
}
