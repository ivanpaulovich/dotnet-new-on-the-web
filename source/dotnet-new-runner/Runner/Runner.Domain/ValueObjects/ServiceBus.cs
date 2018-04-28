namespace Runner.Domain.ValueObjects
{
    public class ServiceBus
    {
        public string Text { get; private set; }

        public ServiceBus(string text)
        {
            this.Text = text;
        }

        public override string ToString()
        {
            return Text.ToString();
        }

        public static implicit operator ServiceBus(string text)
        {
            return new ServiceBus(text);
        }
    }
}
