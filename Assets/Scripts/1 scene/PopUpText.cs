using UnityEngine;
using System.Collections;

public class PopUpText : MonoBehaviour {

    public GameObject boy, ladder;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x - boy.transform.position.x < 2 && ladder.activeSelf)
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        else
            gameObject.GetComponent<MeshRenderer>().enabled = false;


    }
}
