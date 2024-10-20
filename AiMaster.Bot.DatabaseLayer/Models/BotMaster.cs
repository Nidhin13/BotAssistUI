using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiMaster.Bot.DatabaseLayer.Models
{
    public class BotMaster : BaseModel
    {
        public int BotId { get; set; }
        public string Name { get; set; }

        public Guid Guid { get; set; }

        public string SupportUrl { get; set; }
        public string ImageUrl { get; set; }
        public string FaqUrl { get; set; }
        public string AssistantId { get; set; }
        public bool Active { get; set; }
    }
}
