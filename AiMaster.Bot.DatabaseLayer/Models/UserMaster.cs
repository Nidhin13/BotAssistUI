using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiMaster.Bot.DatabaseLayer.Models
{
    public class UserMaster : BaseModel
    {
        public int UserId { get; set; }
        public string UserName { get; set;}
        public string EmailId { get; set; }
    }
}
