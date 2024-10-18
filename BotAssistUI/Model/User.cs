namespace BotAssistUI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } // Indicates if the user is currently using the app
    }
}
