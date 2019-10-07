using UnityEngine;
using System.Collections;

public class BoyMovement : MonoBehaviour {

    private float speed = 4f;

    public bool canMove;

    public bool lookingRight { get; set; }

    public Animator anim;

    // Use this for initialization
    void Start () {

        lookingRight = false;

        canMove = true;

    }
	
	// Update is called once per frame
	void Update () {

        if (canMove && Input.GetAxis("Horizontal") !=0)
        {
            Move();
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }

    }

    public void Flip()
    {
        lookingRight = !lookingRight;

        Vector2 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }

    public void Move()
    {
        float move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !lookingRight)
            Flip();

        if (move < 0 && lookingRight)
            Flip();

        anim.SetFloat("Speed", Mathf.Abs(move));
    }
}
