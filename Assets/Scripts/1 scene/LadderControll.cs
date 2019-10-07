using UnityEngine;
using System.Collections;

public class LadderControll : MonoBehaviour {

    private float speed = 4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Boy" && Input.GetKey(KeyCode.W))
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }
}
