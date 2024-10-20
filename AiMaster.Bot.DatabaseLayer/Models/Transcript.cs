using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiMaster.Bot.DatabaseLayer.Models
{
    public class Transcript : BaseModel
    {
        public int TransactionId { get; set; }
        public int BotUserId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
