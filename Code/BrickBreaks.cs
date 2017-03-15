using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreaks : MonoBehaviour {

	void OnCollisionEnter(){
        Manager.level.destroyBrick();
        Destroy(gameObject);
    }

}
