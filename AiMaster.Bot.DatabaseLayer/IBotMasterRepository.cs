using AiMaster.Bot.DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiMaster.Bot.DatabaseLayer
{
    public interface IBotMasterRepository
    {
        public int AddBot(BotMaster botMaster);
        public IEnumerable<BotMaster> GetAll();
        public BotMaster GetBotByGuid(Guid guid);

        public BotMaster GetBotById(int botId);
    }
}
