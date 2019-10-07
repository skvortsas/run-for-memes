using UnityEngine;
using System.Collections;

public class SecondCutScene : MonoBehaviour {

    public BoyMovement moveBoy;

    public GameObject canvasCutScene;

    public CutScene cutScene;

    public Camera cutSceneCamera, mainCamera;

    public bool isShooting;

    private Vector2 target;

    private bool watchedButton, done;

	// Use this for initialization
	void Start () {

        target = new Vector3(40,-3, -10);
	
	}
	
	// Update is called once per frame
	void Update () {

        CheckToShoot();

        if (isShooting && !watchedButton)
        {
            cutSceneCamera.transform.position = Vector3.MoveTowards(new Vector3(cutSceneCamera.transform.position.x, cutSceneCamera.transform.position.y, -10), target, 8f*Time.deltaTime);
        }
        if (cutSceneCamera.transform.position.y < -2.8f)
            watchedButton = true;

        if (watchedButton && !done)
        {
            cutSceneCamera.transform.position = Vector3.MoveTowards(new Vector3(cutSceneCamera.transform.position.x, cutSceneCamera.transform.position.y, -10), mainCamera.transform.position, 8f*Time.deltaTime);

            if (cutSceneCamera.transform.position.x - mainCamera.transform.position.x < 0.1f && !done && watchedButton)
            {
                moveBoy.canMove = true;

                isShooting = false;

                done = true;
            }
        }

        
	
	}

    void CheckToShoot()
    {
        if (!moveBoy.canMove && cutScene.secondCutSceneIsShooting)
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
