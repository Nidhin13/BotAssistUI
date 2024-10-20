using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiMaster.Bot.DatabaseLayer
{
    public abstract class BaseRepository
    {
        protected readonly string _connectionString;
        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
