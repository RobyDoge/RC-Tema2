namespace TokenSimulation
{
    public class Computer
    {
        public string Ip { get; set; }
        public Token LocalToken { get; set; }

        public string Message { get; set; }

        public Computer()
        {
        }

        public override string ToString()
        {
            return Message == null ? $"{Ip}" : $"{Ip}. {Message}";
        }
    }
}