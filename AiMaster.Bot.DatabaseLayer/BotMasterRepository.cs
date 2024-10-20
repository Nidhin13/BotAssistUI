using AiMaster.Bot.DatabaseLayer.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AiMaster.Bot.DatabaseLayer
{
    public class BotMasterRepository : BaseRepository, IBotMasterRepository
    {
        private string insertSql = "INSERT INTO BotMaster(Name,Guid,SupportUrl,ImageUrl, FaqUrl,AssistantId,Active,CreateTimestamp,UpdateTimestamp,CreatedBy,UpdatedBy) VALUES (@Name,@Guid,@SupportUrl,@ImageUrl,@FaqUrl,@AssistantId,@Active,@Createtimestamp,@UpdateTimestamp,@CreatedBy,@UpdatedBy);SELECT SCOPE_IDENTITY();";
        private string GetAllBotsSql = "SELECT BotId, [Name],Guid,SupportUrl,ImageUrl, FaqUrl,AssistantId,Active,CreateTimestamp,UpdateTimestamp,CreatedBy,UpdatedBy FROM BotMaster";
        private string GetBotByGuidSql = "SELECT BotId, [Name],Guid,SupportUrl,ImageUrl, FaqUrl,AssistantId,Active,CreateTimestamp,UpdateTimestamp,CreatedBy,UpdatedBy FROM BotMaster WHERE Guid = @Guid";
        private string GetBotByIdSql = "SELECT BotId, [Name],Guid,SupportUrl,ImageUrl, FaqUrl,AssistantId,Active,CreateTimestamp,UpdateTimestamp,CreatedBy,UpdatedBy FROM BotMaster WHERE BotId = @BotId";

        public BotMasterRepository(string connnectionString) : base(connnectionString)
        {

        }
        public int AddBot(BotMaster botMaster)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                var id = connection.ExecuteScalar<int>(insertSql, botMaster);
                botMaster.BotId = id;
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<BotMaster> GetAll()
        {
                using var connection = new SqlConnection(_connectionString);
               return connection.Query<BotMaster>(GetAllBotsSql);
        }

        public BotMaster GetBotByGuid(Guid guid)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirst<BotMaster>(GetBotByGuidSql, new { Guid = guid });
        }

        public BotMaster GetBotById(int botId)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirst<BotMaster>(GetBotByIdSql, new { BotId = botId });
        }
    }
}
