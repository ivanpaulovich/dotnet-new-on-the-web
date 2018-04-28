namespace Runner.Domain.ValueObjects
{
    public class SkipRestore
    {
        public string Text { get; private set; }

        public SkipRestore(string text)
        {
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
