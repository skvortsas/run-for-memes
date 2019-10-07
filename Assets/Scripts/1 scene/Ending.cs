using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {

    public Animator grillAnimator, necromancerAnimator;

    public GameObject flowers, grill, necromancer;

    private bool hasGiven;

    public bool stealNow, kek;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void GaveFlowers()
    {
        if (!hasGiven)
        {
            grillAnimator.SetTrigger("GetFlowers");

            flowers.SetActive(false);

            hasGiven = true;

            necromancer.SetActive(true);

            necromancerAnimator.SetTrigger("Attack");
        }
    }

    void Die()
    {
        SceneManager.LoadScene(0);
    }

    void GetHit()
    {
        GetComponent<Animator>().SetBool("GetingHit", false);
    }

    void FallFlat()
    {
        necromancerAnimator.SetBool("StealGrill", true);

        stealNow = true;
    }
}
