namespace OrdersWebApi.Domain.ValueObjects
{
    public class ServiceBus
    {
        public string Text { get; private set; }
        private static readonly string[] allowedValues = { "kafka", "none" };
        
        public ServiceBus(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new System.Exception($"Invalid value.");
            }

            bool isValid = false;

            foreach (string value in allowedValues)
            {
                if (string.Compare(value, text, true) == 0)
                {
                    isValid = true;
                }
            }

            if (!isValid)
                throw new System.Exception($"Invalid value.");

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
