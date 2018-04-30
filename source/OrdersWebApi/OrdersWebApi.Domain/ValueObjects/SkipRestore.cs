namespace OrdersWebApi.Domain.ValueObjects
{
    public class SkipRestore
    {
        public string Text { get; private set; }
        private static readonly string[] allowedValues = { "true", "false" };
        
        public SkipRestore(string text)
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

        public static implicit operator SkipRestore(string text)
        {
            return new SkipRestore(text);
        }
    }
}
