using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RpcManager : NetworkBehaviour
{
    private RemoteObject fbxObj;

    void Update()
    {
        GetInput();
        UpdateFbxObject();
    }

    /*
        Try to update fbxObject transform (see if any other components are necessary to be tracked
    */
    private void UpdateFbxObject()
    {
        if ( fbxObj != null && fbxObj.lastUpdate.ChangeSavingTransform(fbxObj.gameObject.transform))
        {
            //if the object's lastUpdate is changed, set dirty bit to serialize new data
            SetDirtyBit(1);
        }
    }

    /*
        Simple method used to create a placeholder
    */
    private void GetInput()
    {
       if (fbxObj == null)
        {
            if (Input.GetKeyDown(KeyCode.P) && isServer)
            {
                fbxObj = new RemoteObject("fbxObj");
                RpcCreateFbxObj(fbxObj.path);
            }
        }
    }

    /*
        Create the same object in all clients
        (using path, maybe a download? a network folder path? just a name, to find within a 
        predefined folder?)
        
        >>>Create a way to do the same when a new client connects and the object is already in scene.
    */
    [ClientRpc]
    private void RpcCreateFbxObj(string path)
    {
        fbxObj = new RemoteObject(path); 
    }

    public override bool OnSerialize(NetworkWriter writer, bool initialState)
    {
        bool needToUpdate = false;
        
        if (fbxObj != null)
        {
            //Call an fbxobj method to write whatever is necessary, return true if "needToUpdate"
            writer.Write(fbxObj.gameObject.transform.position);
            needToUpdate = true;
        }
        return needToUpdate;
    }

    public override void OnDeserialize(NetworkReader reader, bool initialState)
    {
        /*
            Interpolate: pass reader as parameter to fbxobj 
        */
        fbxObj.gameObject.transform.position = reader.ReadVector3();
    }

}
