using Discord;
using Discord.Net;
using Discord.WebSocket;
using Discord.Commands;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace csharpi.Modules
{
    [Group("rf")]
    // using 'Group' allows the command rf to be the main command, then sub command as the alias for task, then the main argument/parameter
    // for commands to be available, and have the Context passed to them, we must inherit ModuleBase
    public class RuneFactory : ModuleBase
    {
        // command for RuneFactory4 character stats
        [Command("RFCharacter")]
        [Alias("character")]
        [Summary("Access Rune Factory Data.")]
        public async Task RF4CharStat([Remainder]string args = null)
        {
            // initialize empty string builder for reply
            var sb = new StringBuilder();
            // let's use an embed for this one!
            var embed = new EmbedBuilder();
            // get user info from the Context
            var user = Context.User;

            if(args == null){
                sb.AppendLine($"Please supply a character name. \n");
                await ReplyAsync(sb.ToString());
                return;
            }

            // lowercase all characters
            args = args.ToLower();
            // re-capitalize first letter
            args = args.First().ToString().ToUpper() + args.Substring(1);
            // get the wiki page, the parentPath can come from another file, like config
            var characterPage = "https://therunefactory.fandom.com/wiki/"+args;

            embed.WithAuthor($"{args.ToUpper()}", null, characterPage);
            sb.AppendLine($"Here {user.Mention} \n");

            // this will reply with the embed
            await ReplyAsync(sb.ToString(), false, embed.Build());

        }
    }
}