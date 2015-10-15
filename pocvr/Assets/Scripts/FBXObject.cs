using UnityEngine;
using System.Collections;

public class FBXObject
{
    public GameObject gameObject { get; set; }
    public string path { get; set; }
    public SavingTransform lastUpdate { get; set; }

    public FBXObject(string path)
    {
        gameObject = new GameObject(path);
        this.path = path;
        lastUpdate = new SavingTransform(gameObject.transform);
    }
}