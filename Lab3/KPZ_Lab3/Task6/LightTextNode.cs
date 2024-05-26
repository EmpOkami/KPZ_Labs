public class LightTextNode : LightNode
{
    public string Text { get; private set; }

    public LightTextNode(string text)
    {
        Text = text;
    }

    public override string ToString()
    {
        return Text;
    }
}
