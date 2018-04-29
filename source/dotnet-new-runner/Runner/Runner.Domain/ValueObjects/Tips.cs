namespace Runner.Domain.ValueObjects
{
    public class Tips
    {
        public string Text { get; private set; }
        private static readonly string[] allowedValues = { "true", "false" };
        
        public Tips(string text)
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

        public static implicit operator Tips(string text)
        {
            return new Tips(text);
        }
    }
}
