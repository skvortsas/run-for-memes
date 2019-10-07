using UnityEngine;
using System.Collections;

public class BoyController : MonoBehaviour {

    private float groundRadius = 0.05f, jumpForce = 1000f;

    public BoyMovement moveBoy;

    private bool grounded;
    [SerializeField]
    public int flowers { get; set; }

    public int lifes { get; set; }

    public Animator anim;

    public Transform groundCheck;

    public LayerMask whatIsGround;


    // Use this for initialization
    void Start () {

        flowers = 0;

        lifes = 3;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        GroundCheck();

        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
    }

    void Update()
    {
        Jumping();
    }

    void GroundCheck()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        anim.SetBool("Grounded", grounded);
    }

    void Jumping()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Grounded", false);

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }
}
