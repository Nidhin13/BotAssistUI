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
    public class BotDomainRepository : BaseRepository, IBotDomainRepository
    {
        private string insertSql = "INSERT INTO [dbo].[BotDomain] ([BotId],[ProductName],[ProductLinkUrl],[ProductUrl],[OpenAiFileId],[Active],[Createtimestamp],[UpdateTimestamp],[CreatedBy],[UpdatedBy]) VALUES(@BotId,@ProductName,@ProductLinkUrl,@ProductUrl,@OpenAiFileId,@Active,@Createtimestamp,@UpdateTimestamp,@CreatedBy,@UpdatedBy); SELECT SCOPE_IDENTITY();";
        private string GetAllBotDemainsSql = "SELECT [DomainId],[BotId],[ProductName],[ProductLinkUrl],[ProductUrl],[OpenAiFileId],[Active],[Createtimestamp],[UpdateTimestamp],[CreatedBy],[UpdatedBy] FROM BotDomain";
        private string GetBotDomainByBotIdSql = "SELECT [DomainId],[BotId],[ProductName],[ProductLinkUrl],[ProductUrl],[OpenAiFileId],[Active],[Createtimestamp],[UpdateTimestamp],[CreatedBy],[UpdatedBy] FROM BotDomain WHERE BotId = @BotId";
        private string deleteByBotIdSql = "DELETE FROM [dbo].[BotDomain] WHERE BotId = @BotId";
        public BotDomainRepository(string connnectionString) : base(connnectionString)
        {

        }

        public int AddBotDomain(BotDomain botDomain)
        {
            using var connection = new SqlConnection(_connectionString);
            var id = connection.ExecuteScalar<int>(insertSql, botDomain);
            botDomain.DomainId = id;
            return id;
        }

        public void Delete(int botId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(deleteByBotIdSql, new { BotId = botId });
        }

        public IEnumerable<BotDomain> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<BotDomain>(GetAllBotDemainsSql);
        }

        public BotDomain GetDomainByBotId(int botId)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirst<BotDomain>(GetAllBotDemainsSql, new { BotId = botId });
        }
    }
}
