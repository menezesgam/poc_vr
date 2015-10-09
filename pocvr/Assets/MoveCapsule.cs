using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MoveCapsule : NetworkBehaviour
{

    void Update()
    {
        if (isLocalPlayer)
        {
            float vertical = 0, horizontal = 0;

            if (Input.GetKey(KeyCode.W))
            {
                vertical = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                vertical = -1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                horizontal = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                horizontal = 1;
            }

            transform.Translate(new Vector3(horizontal * 2.0f * Time.deltaTime, vertical * 2.0f * Time.deltaTime, 0));
        }
    }

    [Command]
    private void CmdTestPrivate(int value)
    {
    }
}
