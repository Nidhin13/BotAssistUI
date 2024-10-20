using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiMaster.Bot.DatabaseLayer.Models
{
    public class BotDomain : BaseModel
    {
        public int DomainId { get; set; }
        public int BotId { get; set; }
        public string ProductName { get; set; }
        
        public string ProductLinkUrl { get; set; }
        public string ProductUrl { get; set; }
        public string OpenAiFileId { get; set; }
        public bool Active { get; set; }
    }
}
