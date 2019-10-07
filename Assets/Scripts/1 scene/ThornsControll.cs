using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ThornsControll : MonoBehaviour {

    public BoyController controllBoy;

    public BoyMovement moveBoy;

    public GameObject boy;

    public Animator boyAnimator;

    public GameObject leftHeart, middleHeart, rightHeart;

    private Vector2 hitForce, stop;

	// Use this for initialization
	void Start () {

        hitForce = new Vector2(-1000f, 1000f);

        stop = new Vector2(0,0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Boy")
        {
            if (transform.position.x > boy.transform.position.x)
            {
                boy.GetComponent<Rigidbody2D>().AddForce(hitForce);
            }
            else
            { 
                boy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-hitForce.x, hitForce.y));
            }

            GetAttaked();
        }
    }

    public void GetAttaked()
    {
        if (controllBoy.lifes > 1)
        {
            GetHit();
        }
        else
        {
            boyAnimator.SetBool("GetingHit", true);

            moveBoy.canMove = false;

            boy.GetComponent<Rigidbody2D>().velocity = stop;

            boy.GetComponent<Rigidbody2D>().mass = 100000;

            middleHeart.SetActive(false);

            controllBoy.lifes--;

            boyAnimator.SetTrigger("Dead");
        }
    }

    void GetHit()
    {
        boyAnimator.SetBool("GetingHit", true);

        boyAnimator.SetTrigger("Hit");

        if (controllBoy.lifes == 3)
        {
            leftHeart.SetActive(false);
        } else if (controllBoy.lifes == 2)
        {
            rightHeart.SetActive(false);
        }
        controllBoy.lifes--;
    }
}
