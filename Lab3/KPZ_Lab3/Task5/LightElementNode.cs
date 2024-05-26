using System;
using System.Collections.Generic;
using System.Text;

public class LightElementNode : LightNode
{
    public string TagName { get; set; }
    public bool IsBlock { get; set; }
    public bool IsSelfClosing { get; set; }
    public List<string> CssClasses { get; private set; }
    public List<LightNode> Children { get; private set; }

    public LightElementNode(string tagName, bool isBlock, bool isSelfClosing)
    {
        TagName = tagName;
        IsBlock = isBlock;
        IsSelfClosing = isSelfClosing;
        CssClasses = new List<string>();
        Children = new List<LightNode>();
    }

    public override string OuterHTML
    {
        get
        {
            return OuterHTMLWithIndent(0);
        }
    }

    public override string InnerHTML
    {
        get
        {
            return InnerHTMLWithIndent(0);
        }
    }

    private string OuterHTMLWithIndent(int indentLevel)
    {
        StringBuilder sb = new StringBuilder();
        string indent = new string(' ', indentLevel * 4);

        sb.Append($"{indent}<{TagName}");

        if (CssClasses.Count > 0)
        {
            sb.Append($" class=\"{string.Join(" ", CssClasses)}\"");
        }

        if (IsSelfClosing)
        {
            sb.Append(" />");
        }
        else
        {
            sb.Append(">");
            if (Children.Count > 0)
            {
                sb.AppendLine();
                sb.Append(InnerHTMLWithIndent(indentLevel + 1));
                sb.AppendLine();
                sb.Append($"{indent}</{TagName}>");
            }
            else
            {
                sb.Append($"</{TagName}>");
            }
        }

        return sb.ToString();
    }

    private string InnerHTMLWithIndent(int indentLevel)
    {
        StringBuilder sb = new StringBuilder();
        string indent = new string(' ', indentLevel * 4);

        foreach (var child in Children)
        {
            if (child is LightElementNode)
            {
                sb.AppendLine(((LightElementNode)child).OuterHTMLWithIndent(indentLevel));
            }
            else
            {
                sb.Append($"{indent}{child.OuterHTML}");
            }
        }

        return sb.ToString();
    }

    public void AddChild(LightNode child)
    {
        if (!IsSelfClosing)
        {
            Children.Add(child);
        }
        else
        {
            throw new InvalidOperationException("Cannot add children to a self-closing tag.");
        }
    }

    public void AddClass(string cssClass)
    {
        CssClasses.Add(cssClass);
    }
}
