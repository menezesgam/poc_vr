using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RpcTest : NetworkBehaviour
{

    private FBXObject fbxObj;
    public bool hasChanges;

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {

       if (fbxObj != null)
        {
            if (fbxObj.lastUpdate.ChangeSavingTransform(fbxObj.gameObject.transform))
            {
                hasChanges = true;
                SetDirtyBit(1);
            }
            if (Input.GetKeyDown(KeyCode.D) && isServer)
            {
                fbxObj.gameObject.transform.Translate(new Vector3(2.0f, 0f, 0f));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P) && isServer)
            {
                fbxObj = new FBXObject("nipo");
                RpcCreateFbxObj(fbxObj.path);
            }
        }
    }

    [ClientRpc]
    private void RpcCreateFbxObj(string path)
    {
        fbxObj = new FBXObject(path); 
    }

    public override bool OnSerialize(NetworkWriter writer, bool initialState)
    {
        bool needToUpdate = false;
        
        if (hasChanges && fbxObj != null)
        {
            writer.Write(fbxObj.gameObject.transform.position);
            hasChanges = false;
            needToUpdate = true;
        }
        print("SERIALIZE " + needToUpdate);
        return needToUpdate;
    }

    public override void OnDeserialize(NetworkReader reader, bool initialState)
    {
        print("SERIALIZE");
        fbxObj.gameObject.transform.position = reader.ReadVector3();
    }

}
