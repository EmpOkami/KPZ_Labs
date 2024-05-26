using System.Collections.Generic;
using System.Text;

public class LightElementNode : LightNode
{
    public LightElementType ElementType { get; private set; }
    public List<string> CssClasses { get; private set; }
    public List<LightNode> Children { get; private set; }

    public LightElementNode(LightElementType elementType, List<string> cssClasses = null)
    {
        ElementType = elementType;
        CssClasses = cssClasses ?? new List<string>();
        Children = new List<LightNode>();
    }

    public void AddChild(LightNode child)
    {
        Children.Add(child);
    }

    public string OuterHTML()
    {
        StringBuilder html = new StringBuilder();
        html.Append($"<{ElementType.TagName}");

        if (CssClasses.Count > 0)
        {
            html.Append($" class=\"{string.Join(" ", CssClasses)}\"");
        }

        if (ElementType.ClosingType == "single")
        {
            html.Append(" />");
        }
        else
        {
            html.Append(">");
            html.Append(InnerHTML());
            html.Append($"</{ElementType.TagName}>");
        }

        return html.ToString();
    }

    public string InnerHTML()
    {
        StringBuilder html = new StringBuilder();
        foreach (var child in Children)
        {
            if (child is LightTextNode textNode)
            {
                html.Append(textNode.Text);
            }
            else if (child is LightElementNode elementNode)
            {
                html.Append(elementNode.OuterHTML());
            }
        }
        return html.ToString();
    }
}
