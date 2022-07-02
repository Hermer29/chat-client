namespace ChatClient.ChatApi.Serialization
{
    internal class UserData : FaultableResult
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string UserName { get; set; }
    }
}
