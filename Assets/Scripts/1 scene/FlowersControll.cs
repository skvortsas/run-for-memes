using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersControll : MonoBehaviour {

    public BoyController boy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Boy")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                boy.flowers++;

                gameObject.SetActive(false);
            }
        }

    }
}
