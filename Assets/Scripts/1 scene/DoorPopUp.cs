using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPopUp : MonoBehaviour {

    public GameObject door, flower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!door.activeSelf)
            gameObject.SetActive(false);

        if (!flower.activeSelf)
            gameObject.SetActive(false);
		
	}
}
