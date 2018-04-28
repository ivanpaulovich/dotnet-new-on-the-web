namespace Runner.Domain.ValueObjects
{
    public class Tips
    {
        public string Text { get; private set; }

        public Tips(string text)
        {
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
