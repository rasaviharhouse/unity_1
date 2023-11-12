using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {
    public string name;
    public string description;
    public Sprite icon;

    public Item(string name, string description, Sprite icon)
    {
        this.name = name;
        this.description = description;
        this.icon = icon;
    }

    public Sprite getSprite()
    {
        return icon;
    }

    public string getName()
    {
        return name;
    }
}
