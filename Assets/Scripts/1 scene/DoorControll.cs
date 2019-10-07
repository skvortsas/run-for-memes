using UnityEngine;
using System.Collections;
using System;

public class DoorControll : MonoBehaviour {

    public GameObject boy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        OpenTheDoor();
	
	}

    void OpenTheDoor()
    {
        if (Math.Abs(transform.position.x) - Math.Abs(boy.transform.position.x) < 1.5f && Input.GetKeyDown(KeyCode.E) && Math.Abs(transform.position.y) - Math.Abs(boy.transform.position.y) < 2f && transform.position.y > boy.transform.position.y)
            gameObject.SetActive(false);
    }
}
