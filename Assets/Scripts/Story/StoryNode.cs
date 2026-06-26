using System;
using System.Collections.Generic;

[Serializable]
public class StoryNode
{
    public int id;

    public string type;

    public string speaker;

    public string content;

    public int nextId;

    public List<ChoiceOption> options;
}
