using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public float launchSpeed = 500f;

    private Rigidbody rigBod;
    private bool active;

	void Awake() {

        rigBod = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space) && active == false)
        {
            //Unbinds from platform and puts in play
            transform.parent = null;
            active = true;
            rigBod.isKinematic = false;
            //launchSpeed must be in 'x' and 'y' position to fire angular
            rigBod.AddForce(new Vector3(launchSpeed, launchSpeed, 0));
        }

	}
}
