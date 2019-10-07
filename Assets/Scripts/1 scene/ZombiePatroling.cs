using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ZombiePatroling : MonoBehaviour {

    public GameObject zombie;

    private float speed = 2f;

    private Vector2 targetTop, targetMid, hitForce;

    private float topLeftPoint = 6, topRightPoint = 16.5f, midLeftPoint = 14, midRightPoint = 25, delta = 0.1f;

    public ThornsControll atac;

	// Use this for initialization
	void Start () {

        if (zombie.transform.position.y > 14)
            targetTop.y = zombie.transform.position.y;

        if (zombie.transform.position.y < 14 && transform.position.y > 3)
            targetMid.y = zombie.transform.position.y;

        hitForce = new Vector2(-8500f, 1000f);
	
	}
	
	// Update is called once per frame
	void Update () {

        movement();

    }

    void Flip()
    {
        Vector2 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Boy")
            GetAttaked();
    }

    void GetAttaked()
    {
        if (transform.position.x > atac.boy.transform.position.x)
        {
            atac.boy.GetComponent<Rigidbody2D>().AddForce(hitForce);
        }
        else
        {
            atac.boy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-hitForce.x, hitForce.y));
        }

            atac.GetAttaked();
    }

    void movement()
    {
        if (zombie.transform.position.y > 14)
        {
            if (zombie.transform.position.x < topLeftPoint + delta)
            {
                targetTop.x = topRightPoint;
                Flip();
            }

            if (zombie.transform.position.x > topRightPoint - delta)
            {
                targetTop.x = topLeftPoint;
                Flip();
            }

            zombie.transform.position = Vector2.MoveTowards(zombie.transform.position, targetTop, speed * Time.deltaTime);

        } else if (zombie.transform.position.y < 14 && zombie.transform.position.y > 3)
        {
            if (zombie.transform.position.x < midLeftPoint + delta)
            {
                targetMid.x = midRightPoint;
                Flip();
            }

            if (zombie.transform.position.x > midRightPoint - delta)
            {
                targetMid.x = midLeftPoint;
                Flip();
            }

            zombie.transform.position = Vector2.MoveTowards(zombie.transform.position, targetMid, speed * Time.deltaTime);
        }
    }
}
