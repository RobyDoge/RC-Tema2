namespace TokenSimulation
{
    public class Computer
    {
        public string Ip { get; set; }
        private Token Token { get; set; } = new Token();
        
        public string Message { get; set; }

        public Computer()
        {
        }

        public override string ToString()
        {
            return Message==null ? $"{Ip}" : $"{Ip}. Message = {Message}";
        }
    }
}