using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string gameTitle;
    public images images;
    public List<Differences> differences;
}


[System.Serializable]
public class images
{
    public string image1;
    public string image2;
}


[System.Serializable]
public class Differences
{
    public float x, y, width, height;
}
