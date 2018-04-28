namespace Runner.Domain.ValueObjects
{
    public class DataAccess
    {
        public string Text { get; private set; }

        public DataAccess(string text)
        {
            this.Text = text;
        }

        public override string ToString()
        {
            return Text.ToString();
        }

        public static implicit operator DataAccess(string text)
        {
            return new DataAccess(text);
        }
    }
}
