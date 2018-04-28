namespace Runner.Domain.ValueObjects
{
    public class UserInterface
    {
        public string Text { get; private set; }

        public UserInterface(string text)
        {
            this.Text = text;
        }

        public override string ToString()
        {
            return Text.ToString();
        }

        public static implicit operator UserInterface(string text)
        {
            return new UserInterface(text);
        }
    }
}
