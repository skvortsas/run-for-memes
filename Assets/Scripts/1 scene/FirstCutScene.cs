using UnityEngine;
using System.Collections;

public class FirstCutScene : MonoBehaviour {

    public CutScene cameras;

    public bool isShooting;

    public Camera cutSceneCamera, mainCamera;

    private float zombieSpeed = 1.5f, xtarget = 20;

    private Vector3 target;

    public BoyMovement moveBoy;

    public GameObject canvasCutScene;


	// Use this for initialization
	void Start () {

        target = new Vector3(xtarget, transform.position.y, transform.position.z);
	
	}
	
	// Update is called once per frame
	void Update () {

        CheckToShoot();

        if (isShooting)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, zombieSpeed * Time.deltaTime);

            if (transform.position.x == xtarget)
            {
                GetComponent<Animator>().SetTrigger("TuchedTheThorn");
            }
        }
	}

    void Die()
    {
        isShooting = false;

        moveBoy.canMove = true;

        transform.position = new Vector2(-19, 0);


    }

    void CheckToShoot()
    {
        if (!moveBoy.canMove && cameras.firstCutSceneIsShooting)
        {
            canvasCutScene.SetActive(true);

            isShooting = true;
        }
        else
        {
            canvasCutScene.SetActive(false);

            isShooting = false;
        }
    }
}
