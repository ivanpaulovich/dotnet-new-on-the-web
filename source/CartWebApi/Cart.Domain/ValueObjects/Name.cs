namespace Cart.Domain.ValueObjects
{
    using System.Linq;

    public class Name
    {
        public string Text { get; private set; }
        
        public Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new System.Exception($"Name is mandatory.");
            }

            if (!text.All(char.IsLetterOrDigit))
            {
                throw new System.Exception($"Name expected to be only letters and digits.");
            }

            if (text.Length > 32)
            {
                throw new System.Exception($"Name should not be larger that 32 characters.");
            }

            this.Text = text;
        }

        public override string ToString()
        {
            return Text.ToString();
        }

        public static implicit operator Name(string text)
        {
            return new Name(text);
        }
    }
}
