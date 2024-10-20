using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiMaster.Bot.DatabaseLayer.Models
{
    public class BotUsers : UserMaster
    {
        public int BotUserId { get; set; }
        public int BotId { get; set; }
    }
}
