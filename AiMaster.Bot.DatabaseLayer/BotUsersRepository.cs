using AiMaster.Bot.DatabaseLayer.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiMaster.Bot.DatabaseLayer
{
    public class BotUsersRepository : BaseRepository, IBotUsersRepository
    {
        private string insertUserMasterSql = "IF EXISTS (SELECT 1 FROM UserMaster WHERE name = @Name AND EmailId = @EmailId) BEGIN  SELECT UserId FROM UserMaster WHERE name = 'abc' AND EmailId = 'abc@gmail.com' END ELSE BEGIN insert into UserMaster([Name], emailId, Createtimestamp,UpdateTimestamp,CreatedBy,UpdatedBy) VALUES (@Name, @EmailId,@CreateTimestamp,@UpdateTimestamp, @CreatedBy,@UpdatedBy); SELECT SCOPE_IDENTITY(); END";
        private string insertBotUserSql = "INSERT INTO BotUsers(UserId, BotId, Createtimestamp,UpdateTimestamp,CreatedBy,UpdatedBy) VALUES (@UserId, @BotId,@CreateTimestamp,@UpdateTimestamp, @CreatedBy,@UpdatedBy); SELECT SCOPE_IDENTITY(); END";
        private string GetAllBotUserSql = "SELECT B.UserId, BotUserId, BotId,[Name], EmailId FROM BotUsers B join UserMaster U on B.UserId = U.UserId";
        private string GetBotUsersByBotIdSql = "SELECT B.UserId, BotUserId, BotId,[Name], EmailId FROM BotUsers B join UserMaster U on B.UserId = U.UserId WHERE BotId = @BotId";

        public BotUsersRepository(string connectionString):base(connectionString)
        {

        }
        public int AddBotUser(BotUsers botUser)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    // Dapper
                    var userId = connection.ExecuteScalar<int>(insertUserMasterSql, botUser, transaction: transaction);
                    botUser.UserId = userId;

                    var botUserId = connection.ExecuteScalar<int>(insertBotUserSql, botUser, transaction: transaction);

                    // Dapper Transaction

                    //var affectedRows2 = transaction.Execute(insertBotUser, botUser);

                    transaction.Commit();
                    return botUserId;
                }
            }
        }

        public IEnumerable<BotUsers> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<BotUsers>(GetAllBotUserSql);
            }
        }

        public IEnumerable<BotUsers> GetBotUsersByBotId(int botId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<BotUsers>(GetBotUsersByBotIdSql, new { BotId = botId});
            }
        }
    }
}
