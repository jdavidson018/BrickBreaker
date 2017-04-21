using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public float launchSpeed = 500f;
	public static bool isFire = false;
    private Rigidbody rigBod;
    private bool active;
	public int count = 0;
	public int count1 = 0;
	public int count2 = 0;

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
		
		if(Manager.level.streak == 15 && count == 0){
			rigBod.velocity = new Vector3(0,0,0);
			rigBod.AddForce(launchSpeed, launchSpeed*2,0);
			count++;
		}
		if(Manager.level.streak == 16 && count1 == 0){
			rigBod.velocity = new Vector3(0,0,0);
			rigBod.AddForce(launchSpeed, launchSpeed*2,0);
			count1++;
		}
		if(Manager.level.streak == 17 && count2 == 0){
			rigBod.velocity = new Vector3(0,0,0);
			rigBod.AddForce(launchSpeed, launchSpeed*2,0);
			count2++;
		}
	}
	
	
	/*public void fireBallForce(){
		rigBod.AddForce(new Vector3(launchSpeed, launchSpeed*2, 0));
	}*/
}
