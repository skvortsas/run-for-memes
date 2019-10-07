using UnityEngine;
using System.Collections;

public class ZeroCutScene : MonoBehaviour {

    public BoyMovement moveBoy;

    public GameObject canvasCutScene;

    public CutScene cutScene;

    public Camera cutSceneCamera;

    public bool isShooting, kek;

    public Animator anim, cameraAnim;

    private Vector2 firstTarget, secondTarget;

    private bool watchedGrill, done;

	// Use this for initialization
	void Start () {

        firstTarget = new Vector3(cutSceneCamera.transform.position.x, 20f, -10);

        secondTarget = new Vector3(cutSceneCamera.transform.position.x, -10, -10);

    }
	
	// Update is called once per frame
	void Update () {

        CheckToShoot();

        if (isShooting && !watchedGrill)
        {
            cutSceneCamera.transform.position = Vector3.MoveTowards(new Vector3(cutSceneCamera.transform.position.x, cutSceneCamera.transform.position.y, -10), firstTarget, 8f*Time.deltaTime);

            anim.SetBool("Happy", true);
        }

        if (cutSceneCamera.transform.position.y > 19.9f)
        {
            canvasCutScene.SetActive(true);

            watchedGrill = true;

            anim.SetBool("Happy", false);
        }

        if (watchedGrill && !done)
            cutSceneCamera.transform.position = Vector3.MoveTowards(new Vector3(cutSceneCamera.transform.position.x, cutSceneCamera.transform.position.y, -10), secondTarget, 8f * Time.deltaTime);

        if (cutSceneCamera.transform.position.y < 0.1 && watchedGrill && !done)
        {
            moveBoy.canMove = true;

            isShooting = false;

            done = true;
        }
	
	}

    void CheckToShoot()
    {
        if (!moveBoy.canMove && cutScene.zeroCutSceneIsShooting)
        {
            isShooting = true;
        }
        else
        {
            canvasCutScene.SetActive(false);

            isShooting = false;
        }
    }
}
