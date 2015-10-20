using UnityEngine;
using System.Collections;

public class RemoteObject
{
    public GameObject gameObject { get; set; }
    public string path { get; set; }
    public SavingTransform lastUpdate { get; set; }

    public RemoteObject(string path, params System.Type[] components)
    {
        gameObject = new GameObject(path, components);
        this.path = path;
        lastUpdate = new SavingTransform(gameObject.transform);
    }
}