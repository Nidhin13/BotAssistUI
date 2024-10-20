using AiMaster.Bot.DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiMaster.Bot.DatabaseLayer
{
    public interface IUserMasterRepository
    {
        int AddUser(UserMaster userMaster);
        IEnumerable<UserMaster> GetAll();

        UserMaster GetUserByEmailAndName(string name, string emailId);

    }
}
