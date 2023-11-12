using System.Collections.Generic;

[System.Serializable]
public struct DialogueNode
{
    public string text;
    public string name;
    public List<string> responses;
    public List<int> responseIDs;
    public int ID;
}
