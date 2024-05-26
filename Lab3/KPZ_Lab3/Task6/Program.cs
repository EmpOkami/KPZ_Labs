using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://www.gutenberg.org/cache/epub/1513/pg1513.txt";
        string bookText = await DownloadBookAsync(url);
        string[] lines = bookText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        LightElementFactory factory = new LightElementFactory();
        LightElementNode root = new LightElementNode(factory.GetElementType("div", "block", "pair"));

        foreach (var line in lines)
        {
            LightElementNode element;
            if (line.Length == 0)
            {
                continue;
            }
            if (line == lines[0])
            {
                element = new LightElementNode(factory.GetElementType("h1", "block", "pair"));
            }
            else if (line.Length < 20)
            {
                element = new LightElementNode(factory.GetElementType("h2", "block", "pair"));
            }
            else if (char.IsWhiteSpace(line[0]))
            {
                element = new LightElementNode(factory.GetElementType("blockquote", "block", "pair"));
            }
            else
            {
                element = new LightElementNode(factory.GetElementType("p", "block", "pair"));
            }

            element.AddChild(new LightTextNode(line.Trim()));
            root.AddChild(element);
        }

        Console.WriteLine(root.OuterHTML());
    }

    static async Task<string> DownloadBookAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            return await client.GetStringAsync(url);
        }
    }
}
