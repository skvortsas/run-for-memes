using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryCutScene : MonoBehaviour {

    public CutScene cameras;

    public BoyMovement moveBoy;

    public GameObject boy, leftWall;

    public Animator boyAnimator;

    public bool isShooting, done;

    private Vector3 target;

    private bool turned;

	// Use this for initialization
	void Start () {

        target = new Vector3(-6, -2.531029f, boy.transform.position.z);

        done = false;
	}
	
	// Update is called once per frame
	void Update () {

        CheckToShoot();

		if (isShooting)
        {

            boyAnimator.SetBool("WalkingInside", true);

            if (!turned)
            {
                moveBoy.Flip();

                turned = true;
            }

            boy.transform.position = Vector3.MoveTowards(boy.transform.position, target, Time.deltaTime);

            boy.GetComponent<Rigidbody2D>().velocity = new Vector2(1, boy.GetComponent<Rigidbody2D>().velocity.y);
            

            if (boy.transform.position.x == target.x)
            {
                if (!done)
                    moveBoy.Flip();

                done = true;

                boyAnimator.SetBool("WalkingInside", false);
            }
        }
	}

    void CheckToShoot()
    {
        if (!moveBoy.canMove && cameras.entryCutSceneIsShooting)
        {
            isShooting = true;

            leftWall.SetActive(false);
        }
        else
        {
            isShooting = false;

            leftWall.SetActive(true);
        }
    }
}
