using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour
{


    private float elapsedTime;

    /* 
        This value represents how many times client will send data to server in a second. (maximum recommended = 29)
    */
    public int sendDataToServerRate = 9;
    // Update is called once per frame

    void Start()
    {
        elapsedTime = 0f;
    }
    void Update()
    {
        //   GetInputForAction();
        elapsedTime += Time.deltaTime;
        if (isLocalPlayer &&  elapsedTime >= 1.0f / sendDataToServerRate)
        {
            elapsedTime = 0;
            GetInputForAction();
        }
    }

    /*
        Get keyboard input and store current action according to key stroke
        R = ROTATE;
        Z = ZOOM;
        M = MOVE;
        SPACE = NO_ACTION;
        Use token control.
    */
    private void GetInputForAction()
    {
        Vector3 mousePosition = new Vector3(Input.GetAxis("Mouse X") / Time.deltaTime, Input.GetAxis("Mouse Y") / Time.deltaTime);

        if (Input.GetKey(KeyCode.R))
        {
            CmdRotateObject(mousePosition);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            CmdZoomObject(mousePosition);
        }
        else if (Input.GetKey(KeyCode.M))
        {
            CmdMoveObject(mousePosition);
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            //decide if keep currentaction or just reset.
            CmdResetObjectState();
        }
    }

    private void RotateObject(Vector3 mouseSpeed)
    {
        if (Mathf.Abs(mouseSpeed.x) > Mathf.Abs(mouseSpeed.y))
        {
            transform.Rotate(new Vector3(mouseSpeed.x / 3, 0, 0));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, mouseSpeed.y / 3));
        }
    }

    [Command]
    private void CmdRotateObject(Vector3 mouseSpeed)
    {
        GetInteractiveObject().RotateObject(mouseSpeed);
    }

    [Command]
    private void CmdZoomObject(Vector3 mouseSpeed)
    {
        GetInteractiveObject().ZoomObject(mouseSpeed);
    }

    [Command]
    private void CmdMoveObject(Vector3 mouseSpeed)
    {
        print("CMDMOVE");
        GetInteractiveObject().MoveObject(mouseSpeed);
    }

    [Command]
    private void CmdResetObjectState()
    {
        GetInteractiveObject().ResetObjectState();
    }

    private InteractiveObject GetInteractiveObject()
    {
        return GameObject.FindGameObjectWithTag("InteractiveObject").GetComponent<InteractiveObject>();
    }

    [Command]
    private void CmdOI()
    {
        print("OI");
    }
}
