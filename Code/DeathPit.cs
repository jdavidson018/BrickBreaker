using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPit : MonoBehaviour {

	void OnTriggerEnter()
    {
        Manager.level.lostLife();
    }
}
