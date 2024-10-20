using AiMaster.Bot.DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiMaster.Bot.DatabaseLayer
{
    public interface IBotDomainRepository
    {
        int AddBotDomain(BotDomain botDomain);
        IEnumerable<BotDomain> GetAll();

        BotDomain GetDomainByBotId(int botId);

        void Delete(int botId);
    }
}
