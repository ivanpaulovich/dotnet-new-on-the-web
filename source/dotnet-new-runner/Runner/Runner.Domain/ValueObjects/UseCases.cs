namespace Runner.Domain.ValueObjects
{
    public class UseCases
    {
        public string Text { get; private set; }
        private static readonly string[] allowedValues = { "full", "basic", "readonly", "none" };

        public UseCases(string text)
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

        public static implicit operator UseCases(string text)
        {
            return new UseCases(text);
        }
    }
}
