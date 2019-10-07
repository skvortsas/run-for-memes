using UnityEngine;
using System.Collections;

public class ButtonControll : MonoBehaviour {

    public GameObject ladder;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Box")
            ladder.SetActive(true);
    }
}
