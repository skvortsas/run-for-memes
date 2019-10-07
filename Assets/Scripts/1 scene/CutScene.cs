using UnityEngine;
using System.Collections;

public class CutScene : MonoBehaviour {

    public Camera mainCamera, cutSceneCamera;

    public FirstCutScene firstCutScene;

    public ZeroCutScene zeroCutScene;

    public SecondCutScene secondCutScene;

    public EntryCutScene entryCutScene;

    public BoyMovement moveBoy;

    public bool firstCutSceneIsShooting, zeroCutSceneIsShooting, secondCutSceneIsShooting, entryCutSceneIsShooting;

    private float pointForFirstOne = 16, upperPointForLower = 5, pointForZeroOne = -1, pointForSecondOne = 31;

    private bool changedZeroTime, changedFirstTime, changedSecondTime, changedEntryTime;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if (!firstCutSceneIsShooting && !changedFirstTime)
        {
            ShootFirstOne();
        }

        if (!zeroCutSceneIsShooting && !changedZeroTime)
        {
            ShootZeroOne();
        }

        if (!secondCutSceneIsShooting && !changedSecondTime)
        {
            ShootSecondOne();
        }

        if (!entryCutSceneIsShooting && !changedEntryTime)
        {
            ShootEntryOne();
        }

        if (firstCutSceneIsShooting && firstCutScene.isShooting)
            cutSceneCamera.transform.position = Vector3.MoveTowards(cutSceneCamera.transform.position, mainCamera.transform.position, 0.5f * Time.deltaTime);

        if (firstCutSceneIsShooting && !firstCutScene.isShooting && !changedFirstTime)
        {
            ChangeCameraBack();

            changedFirstTime = true;

            firstCutSceneIsShooting = false;
        }

        if (zeroCutSceneIsShooting && !zeroCutScene.isShooting && !changedZeroTime)
        {
            ChangeCameraBack();

            changedZeroTime = true;

            zeroCutSceneIsShooting = false;
        }

        if (secondCutSceneIsShooting && !secondCutScene.isShooting && !changedSecondTime)
        {
            ChangeCameraBack();

            changedSecondTime = true;

            secondCutSceneIsShooting = false;
        }

        if (entryCutSceneIsShooting && !entryCutScene.isShooting && !changedEntryTime && entryCutScene.done)
        {
            ChangeCameraBack();

            changedEntryTime = true;

            entryCutSceneIsShooting = false;
        }

    }

    void ChangeCameraForFirst()
    {
        mainCamera.enabled = false;

        cutSceneCamera.enabled = true;

        firstCutSceneIsShooting = true;
    }

    void ChangeCameraForZero()
    {
        mainCamera.enabled = false;

        cutSceneCamera.enabled = true;

        zeroCutSceneIsShooting = true;
    }

    void ChangeCameraForSecond()
    {
        mainCamera.enabled = false;

        cutSceneCamera.enabled = true;

        secondCutSceneIsShooting = true;
    }

    void ChangeCameraForEntry()
    {
        mainCamera.enabled = false;

        cutSceneCamera.enabled = true;

        entryCutSceneIsShooting = true;
    } 

    void ChangeCameraBack()
    {
        mainCamera.enabled = true;

        cutSceneCamera.enabled = false;
    }

    void ShootFirstOne()
    {
        if (mainCamera.transform.position.x > pointForFirstOne && mainCamera.transform.position.x < pointForFirstOne + 0.5f && mainCamera.transform.position.y < upperPointForLower)
        {
            cutSceneCamera.transform.position = mainCamera.transform.position;

            moveBoy.canMove = false;

            moveBoy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            firstCutScene.isShooting = true;

            ChangeCameraForFirst();
        }
    }

    void ShootZeroOne()
    {
        if (mainCamera.transform.position.x > pointForZeroOne && mainCamera.transform.position.x < pointForZeroOne + 2.5f && mainCamera.transform.position.y < upperPointForLower && entryCutScene.done)
        {
            cutSceneCamera.transform.position = mainCamera.transform.position;

            moveBoy.canMove = false;

            zeroCutScene.isShooting = true;

            ChangeCameraForZero();
        }
    }

    void ShootSecondOne()
    {
        if (mainCamera.transform.position.x > pointForSecondOne && mainCamera.transform.position.x < pointForSecondOne + 0.5f && mainCamera.transform.position.y < upperPointForLower)
        {
            cutSceneCamera.transform.position = mainCamera.transform.position;

            moveBoy.canMove = false;

            moveBoy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            secondCutScene.isShooting = true;

            ChangeCameraForSecond();
        }
    }

    void ShootEntryOne()
    {
        if (!entryCutScene.done)
        {
            moveBoy.canMove = false;

            entryCutScene.isShooting = true;

            ChangeCameraForEntry();
        }
    }
}
