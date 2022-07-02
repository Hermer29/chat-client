namespace ChatClient.ChatApi.Serialization
{
    internal class FaultableResult
    {
        public bool faulted { get; set; }
        public string reason { get; set; }
    }
}
