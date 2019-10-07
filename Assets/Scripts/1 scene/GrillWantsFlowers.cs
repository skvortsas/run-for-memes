using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillWantsFlowers : MonoBehaviour {

    public BoyController boyFlowers;

    public BoyMovement moveBoy;

    public GameObject boy, grillPopUp, necromancer, userInterface, fadeIn;

    public Animator grillAnimator, boyAnimator;

    public NecromancerControll necromancerControll;

    private Vector2 stop, target;

    [SerializeField]
    private bool gaveFlowers, needToDrag;

	// Use this for initialization
	void Start () {

        stop = new Vector2(0,0);

        target = new Vector2(-21,transform.position.y);
		
	}
	
	// Update is called once per frame
	void Update () {

        if (boy.transform.position.x - transform.position.x < 2 && boy.transform.position.y > 5)
        {
            if (boyFlowers.flowers < 4)
                grillPopUp.SetActive(true);
            else
            {
                CutScene();
            }
        }
        else
        {
            grillPopUp.SetActive(false);
        }

        if (necromancerControll.grillFall)
        {
            GetComponent<Animator>().SetTrigger("GrillFall");

            necromancerControll.grillFall = false;
        }

        if (needToDrag && transform.position.x - necromancer.transform.position.x > 5)
            transform.position = Vector2.MoveTowards(transform.position, target, 3 * Time.deltaTime);

        if (transform.position.x < -9.4f)
        {
            userInterface.SetActive(false);

            fadeIn.SetActive(true);
        }

    }

    void CutScene()
    {
        moveBoy.canMove = false;

        boy.GetComponent<Rigidbody2D>().velocity = stop;

        if (!gaveFlowers)
        {
            boyAnimator.SetTrigger("GiveFlowers");

            gaveFlowers = true;
        }
    }

    void Draging()
    {
        needToDrag = true;
    }
}
