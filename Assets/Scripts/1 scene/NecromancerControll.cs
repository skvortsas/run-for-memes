using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerControll : MonoBehaviour {

    public GameObject boy, grill;

    public Ending ending;

    private Vector2 target;

    public bool grillFall;

    // Use this for initialization
    void Start () {

        target = new Vector3(-15, transform.position.y, -9);

    }
	
	// Update is called once per frame
	void Update () {

        if (ending.stealNow)
        {
            transform.position = new Vector3(transform.position.x, 21, -9);

            transform.position = Vector3.MoveTowards(transform.position, target, 5 * Time.deltaTime);

            if (grill.transform.position.x - transform.position.x > 0)
            {
                grillFall = true;
            }
        }
	}

    void FallFlat()
    {
        boy.GetComponent<Animator>().SetTrigger("DownForCutScene");
    }
}
