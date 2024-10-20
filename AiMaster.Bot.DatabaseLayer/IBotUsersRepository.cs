using AiMaster.Bot.DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiMaster.Bot.DatabaseLayer
{
    public interface IBotUsersRepository
    {
        int AddBotUser(BotUsers botUser);
        IEnumerable<BotUsers> GetAll();
        IEnumerable<BotUsers> GetBotUsersByBotId(int botId);
    }
}
