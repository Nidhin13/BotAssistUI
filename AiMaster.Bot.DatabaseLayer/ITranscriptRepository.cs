using AiMaster.Bot.DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiMaster.Bot.DatabaseLayer
{
    public interface ITranscriptRepository
    {
        int AddTranscript(Transcript transcript);
        IEnumerable<Transcript> GetAll();
        IEnumerable<Transcript> GetByBotId(Transcript transcript);
        IEnumerable<Transcript> GetByBotAndUserId(Transcript transcript);
    }
}
