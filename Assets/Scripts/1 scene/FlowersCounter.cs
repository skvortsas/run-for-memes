using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersCounter : MonoBehaviour {

    public BoyController boy;

    public GameObject firstFlower, secondFlower, ThirdFlower, bouquet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (boy.flowers > 0)
        {
            if (boy.flowers == 1)
                firstFlower.SetActive(true);
            if (boy.flowers == 2)
                secondFlower.SetActive(true);
            if (boy.flowers == 3)
                ThirdFlower.SetActive(true);
            if (boy.flowers == 4)
            {
                firstFlower.SetActive(false);

                secondFlower.SetActive(false);

                ThirdFlower.SetActive(false);

                bouquet.SetActive(true);
            }
        }
		
	}
}
