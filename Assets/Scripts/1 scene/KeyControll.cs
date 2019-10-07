using UnityEngine;
using System.Collections;

public class KeyControll : MonoBehaviour
{

    public GameObject firstDisabledKey, secondDisabledKey, firstKey, secondKey;

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
            if (transform.position.x < 10)
            {
                firstDisabledKey.SetActive(false);

                firstKey.SetActive(true);
            }
            else
            {
                secondDisabledKey.SetActive(false);

                secondKey.SetActive(true);
            }

            transform.position = new Vector2(-19f, 0f);
        }
    }
}
