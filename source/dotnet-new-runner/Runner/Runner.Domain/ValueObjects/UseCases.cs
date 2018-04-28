namespace Runner.Domain.ValueObjects
{
    public class UseCases
    {
        public string Text { get; private set; }

        public UseCases(string text)
        {
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
