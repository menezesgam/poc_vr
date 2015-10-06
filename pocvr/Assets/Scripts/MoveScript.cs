using UnityEngine;
using System.Collections;

public class MoveSCript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float vertical = 0, horizontal = 0;

        if (Input.GetKeyDown(KeyCode.W))
        {
            vertical = 1;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            vertical = -1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            horizontal = -1;
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            horizontal = 1;
        }

        transform.Translate(new Vector3(horizontal * 2.0f * Time.deltaTime, vertical * 2.0f * Time.deltaTime, 0));
    }
}
