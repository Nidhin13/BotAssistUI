using BotAssistUI.Model;
using System.Collections.Generic;
using System.Linq;

namespace BotAssistUI.Service
{
    public class UserService
    {
        private List<User> _users = new List<User>
    {
        new User { Id = 1, Name = "Alice", IsActive = true },
        new User { Id = 2, Name = "Bob", IsActive = true },
        new User { Id = 3, Name = "Charlie", IsActive = false },
        new User { Id = 4, Name = "David", IsActive = true },
    };

        public int GetTotalUsers()
        {
            return _users.Count();
        }

        public int GetActiveUsers()
        {
            return _users.Where(u => u.IsActive).Count();
        }
    }
}
