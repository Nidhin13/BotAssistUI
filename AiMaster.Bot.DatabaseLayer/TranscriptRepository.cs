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
    public class TranscriptRepository : BaseRepository, ITranscriptRepository
    {
        private string insertTranscriptSql = @"INSERT INTO [dbo].[Transcripts]
           ([BotUserId]
           ,[Question]
           ,[Answer]
           ,[Createtimestamp]
           ,[UpdateTimestamp]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           (@BotUserId,
           ,@Question,
           ,@Answer,
           ,@Createtimestamp,
           ,@UpdateTimestamp,
           ,@CreatedBy,
           ,@UpdatedBy)
; SELECT SCOPE_IDENTITY(); END";
        private string GetAllTranscriptSql = @"Transcripts.BotUserId
		 ,TranscriptId
            ,BM.[Name] as BotName
            ,UM.[Name] as UserName
            ,UM.EmailId
           ,[Question]
           ,[Answer]
           ,Transcripts.[Createtimestamp]
           ,Transcripts.[UpdateTimestamp]
           ,Transcripts.[CreatedBy]
           ,Transcripts.[UpdatedBy] FROM Transcripts JOIN BotUsers ON BotUsers.BotUserId = Transcripts.BotUserId
                                        JOIN UserMaster UM ON UM.UserId = BotUsers.UserId 
                                        JOIN BotMaster BM ON BM.BotId = BotUsers.BotId";
           
        private string GetAllByBotIdSql = @"Transcripts.BotUserId
		 ,TranscriptId
            ,BM.[Name] as BotName
            ,UM.[Name] as UserName
            ,UM.EmailId
           ,[Question]
           ,[Answer]
           ,Transcripts.[Createtimestamp]
           ,Transcripts.[UpdateTimestamp]
           ,Transcripts.[CreatedBy]
           ,Transcripts.[UpdatedBy] FROM Transcripts JOIN BotUsers ON BotUsers.BotUserId = Transcripts.BotUserId
                                        JOIN UserMaster UM ON UM.UserId = BotUsers.UserId 
                                        JOIN BotMaster BM ON BM.BotId = BotUsers.BotId
           WHERE BM.BotId = @BotId";
        private string GetTranscriptByUsersAndBotIdSql = @"Transcripts.BotUserId
		 ,TranscriptId
            ,BM.[Name] as BotName
            ,UM.[Name] as UserName
            ,UM.EmailId
           ,[Question]
           ,[Answer]
           ,Transcripts.[Createtimestamp]
           ,Transcripts.[UpdateTimestamp]
           ,Transcripts.[CreatedBy]
           ,Transcripts.[UpdatedBy] FROM Transcripts JOIN BotUsers ON BotUsers.BotUserId = Transcripts.BotUserId
                                        JOIN UserMaster UM ON UM.UserId = BotUsers.UserId 
                                        JOIN BotMaster BM ON BM.BotId = BotUsers.BotId
           WHERE BM.BotId = @BotId and Transcripts.BotUserId = @BotUserId";

        public TranscriptRepository(string connectionString):base(connectionString)
        {

        }

        public int AddTranscript(Transcript transcript)
        {
            using var connection = new SqlConnection(_connectionString);
            var id = connection.ExecuteScalar<int>(insertTranscriptSql, transcript);
            transcript.TransactionId = id;
            return id;
        }

        public IEnumerable<Transcript> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Transcript>(GetAllTranscriptSql);
        }

        public IEnumerable<Transcript> GetByBotAndUserId(Transcript transcript)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Transcript>(GetTranscriptByUsersAndBotIdSql, transcript);
        }

        public IEnumerable<Transcript> GetByBotId(Transcript transcript)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Transcript>(GetAllByBotIdSql, transcript);
        }
    }
}
