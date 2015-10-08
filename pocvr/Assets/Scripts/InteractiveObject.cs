using UnityEngine;
using System.Collections;

public class InteractiveObject : MonoBehaviour {

    /* Possible actions to interact with object */
    public enum InteractiveObjectAction {ROTATE, ZOOM, MOVE, NO_ACTION}

    private InteractiveObjectAction currentAction;
   // private Vector3 lastMousePosition;
    private SavingTransform objectInitialState;


	// Use this for initialization
	void Start () {
       // lastMousePosition = Input.mousePosition;
        objectInitialState = new SavingTransform();
        objectInitialState.Position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        objectInitialState.Rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        objectInitialState.Scale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

        currentAction = InteractiveObjectAction.NO_ACTION;
	}
	
	// Update is called once per frame
	void Update () {
        GetInputForAction();
        TakeAction();
       // lastMousePosition = Input.mousePosition;
    }

    /*
        Get keyboard input and store current action according to key stroke
        R = ROTATE;
        Z = ZOOM;
        M = MOVE;
        SPACE = NO_ACTION;
    */
    private void GetInputForAction()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentAction = InteractiveObjectAction.ROTATE;
        }else if (Input.GetKeyDown(KeyCode.Z))
        {
            currentAction = InteractiveObjectAction.ZOOM;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            currentAction = InteractiveObjectAction.MOVE;
        }else if (Input.GetKeyDown(KeyCode.Space))
        {
            currentAction = InteractiveObjectAction.NO_ACTION;
        }else if (Input.GetKeyDown(KeyCode.Escape))
        {
            //decide if keep currentaction or just reset.
            currentAction = InteractiveObjectAction.NO_ACTION;
            ResetObjectState();
        }
    }

    /*
        Decide which method to invoke and do action //-> Review and refactor
    */
    private void TakeAction()
    {
        //Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePosition = new Vector3(Input.GetAxis("Mouse X")/Time.deltaTime, Input.GetAxis("Mouse Y")/Time.deltaTime);
        switch (currentAction)
        {
            case InteractiveObjectAction.ROTATE:
                RotateObject(mousePosition);
                break;
            case InteractiveObjectAction.ZOOM:
                ZoomObject(mousePosition);
                break;
            case InteractiveObjectAction.MOVE:
                MoveObject(mousePosition);
                break;
            default:
                print("NO ACTION");
                break;
        }
    }

    private void RotateObject(Vector3 mouseSpeed)
    {
        print("ROTATE");
        if (Mathf.Abs(mouseSpeed.x) > Mathf.Abs(mouseSpeed.y))
        {
            transform.Rotate(new Vector3(mouseSpeed.x / 3, 0, 0));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, mouseSpeed.y / 3));
        }
    }

    private void ZoomObject(Vector3 mouseSpeed)
    {
        print("ZOOM");
        Vector3 nextScale = new Vector3(transform.localScale.x + mouseSpeed.x / 2, transform.localScale.y + mouseSpeed.x / 2, transform.localScale.z + mouseSpeed.x / 2);
        transform.localScale = Vector3.Lerp(transform.localScale, nextScale, Time.deltaTime * 0.5f);
    }

    /*Still needs to consider rotation*/
    private void MoveObject(Vector3 mouseSpeed)
    {
        print("MOVE");
        float moveSpeed = 0.010f;
        Vector3 test = Vector3.right * moveSpeed * mouseSpeed.x + Vector3.up * moveSpeed * mouseSpeed.y;
        transform.Translate(test, Space.World);
    }

    /*
        Reset object with initial state
    */
    private void ResetObjectState()
    {
        print("RESET");
        transform.position = new Vector3(objectInitialState.Position.x, objectInitialState.Position.y, objectInitialState.Position.z);
        transform.rotation = new Quaternion(objectInitialState.Rotation.x, objectInitialState.Rotation.y, objectInitialState.Rotation.z, objectInitialState.Rotation.w);
        transform.localScale = new Vector3(objectInitialState.Scale.x, objectInitialState.Scale.y, objectInitialState.Scale.z);
    }

}
