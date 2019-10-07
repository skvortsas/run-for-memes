using UnityEngine;
using System.Collections;

public class SecondKeyControll : MonoBehaviour {

    public GameObject ladder, secondLadder;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Boy")
        {
            ladder.SetActive(true);
            secondLadder.SetActive(true);
        }
    }
}
