using System.Collections.Generic;

public class LightElementFactory
{
    private Dictionary<string, LightElementType> elementTypes = new Dictionary<string, LightElementType>();

    public LightElementType GetElementType(string tagName, string displayType, string closingType)
    {
        string key = $"{tagName}_{displayType}_{closingType}";
        if (!elementTypes.ContainsKey(key))
        {
            elementTypes[key] = new LightElementType(tagName, displayType, closingType);
        }
        return elementTypes[key];
    }
}
