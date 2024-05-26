using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Створюємо елементи
        LightElementNode div = new LightElementNode("div", true, false);
        div.AddClass("container");

        LightElementNode ul = new LightElementNode("ul", true, false);
        ul.AddClass("list");

        LightElementNode li1 = new LightElementNode("li", true, false);
        li1.AddClass("item");
        li1.AddChild(new LightTextNode("Item 1"));

        LightElementNode li2 = new LightElementNode("li", true, false);
        li2.AddClass("item");
        li2.AddChild(new LightTextNode("Item 2"));

        LightElementNode img = new LightElementNode("img", false, true);
        img.AddClass("image");

        // Будуємо структуру
        ul.AddChild(li1);
        ul.AddChild(li2);
        div.AddChild(ul);
        div.AddChild(img);

        // Виводимо HTML
        Console.WriteLine(div.OuterHTML);
    }
}
