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
using DSharpPlus.Interactivity;
using DSharpPlus.CommandsNext.Attributes;
using System.Linq;



namespace Discord_bot_test
{
    public class FunCommands : BaseCommandModule
    {
        static string fileName = "bData.txt";
        List<UserInfo> users = new List<UserInfo>();
        List<string> lines = File.ReadAllLines(fileName).ToList();

        /*
        [Command("ping")]
        [Description("Returns pong")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }
        */

        [Command("addb")]
        [Description("Adds birthday")]

        public async Task addBday(CommandContext ctx, string userID, int month, int bDay)
        {
            

            

            string addToFile = userID + "," + month.ToString() + "," + bDay.ToString();

            lines.Add(addToFile);
            File.WriteAllText(fileName, "");
            File.WriteAllLines(fileName, lines);


            await ctx.Channel.SendMessageAsync("Added user to file").ConfigureAwait(false) ;
        }


        /*

        public async Task delB(CommandContext ctx, string userID)
        {
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                UserInfo newUserInfo = new UserInfo();

                newUserInfo.userID = entries[0];

                newUserInfo.userBirthMonth = entries[1];

                newUserInfo.userBirthDay = entries[2];

                users.Add(newUserInfo);

            }

            foreach (var person in users)
            {
                if(person.userID == userID)
                {
                    lines.

                }
            }
        }
        */

        [Command("listbday")]
        [Description("Lists Birthdays")]

        async Task  listBdays(CommandContext ctx)
        {

            foreach (var line in lines)
                {
                 string[] entries = line.Split(',');
    
              UserInfo newUserInfo = new UserInfo();

                 newUserInfo.userID = entries[0];

                newUserInfo.userBirthMonth = entries[1];

                newUserInfo.userBirthDay = entries[2];

                users.Add(newUserInfo);

                }
            string msg = "";



                foreach (var person in users)
                {
                     msg += "User ID: " + person.userID + " <-> Birthday: " + person.userBirthMonth + "/" + person.userBirthDay + Environment.NewLine;
                
                }
            
                await ctx.Channel.SendMessageAsync(msg).ConfigureAwait(false);

            
            
            
            
        }




    }



}
