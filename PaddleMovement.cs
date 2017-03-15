using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

    public float speed = 0.1f;

    private Vector3 position = new Vector3(0, 0, 0);
	
	// Update is called once per frame
	void Update () {
        // "Horizontal" is predefined axis name in Unity for x
        float xVar = transform.position.x + (Input.GetAxis("Horizontal") * speed);
        //Clamp lets us define borders for the platform
        position = new Vector3(Mathf.Clamp(xVar, -12.4f, 12.4f), 0, 0);
        transform.position = position;
	}
}
