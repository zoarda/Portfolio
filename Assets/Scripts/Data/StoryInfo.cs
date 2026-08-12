using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StoryInfo
{
    public string title;

    public string fileName;

    public Sprite thumbnail;
}
[Serializable]
public class StoryList
{
    public List<StoryInfo> stories;
}
