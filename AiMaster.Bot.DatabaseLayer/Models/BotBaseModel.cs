using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiMaster.Bot.DatabaseLayer.Models
{
    public abstract class BaseModel
    {

        public DateTime CreateTimestamp { get; set; } = DateTime.Now;
        public DateTime UpdateTimestamp { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "Admin";
        public string UpdatedBy { get; set; } = "Admin";

    }
}
