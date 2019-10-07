using UnityEngine;
using System.Collections;

public class CameraPlayerFolow : MonoBehaviour {

    public Transform player;

    public BoyMovement boy;

    private float bottomEdge = 0f, topEdge = 21f, leftEdge = 0f, rightEdge = 45f;

     public Vector3 target;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(player.position.x, player.position.y, -10);

        if (transform.position.y < 0)
            transform.position = new Vector2(transform.position.x, bottomEdge);

        if (transform.position.y > 21)
            transform.position = new Vector2(transform.position.x, topEdge);

        if (transform.position.x < 0)
            transform.position = new Vector2(leftEdge, transform.position.y);

        if (transform.position.x > 45)
            transform.position = new Vector2(rightEdge, transform.position.y);

    }
	
	// Update is called once per frame
	void Update () {

        target = new Vector3(player.position.x, player.position.y, -10);

        GetBeautifull();

        if (target.y < 0)
            target.y = 0;

        if (target.y > 21)
            target.y = 21;

        if (target.x < 0)
            target.x = 0;

        if (target.x > 45)
            target.x = 45;

        transform.position = Vector3.Lerp(transform.position, target, 2f * Time.deltaTime);
	
	}

    void GetBeautifull()
    {
        if (boy.lookingRight)
            target.x += 3;
        else
            target.x -= 3;
    }
}
