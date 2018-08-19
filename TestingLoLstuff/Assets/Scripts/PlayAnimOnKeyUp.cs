using UnityEngine;
using System.Collections;

public class PlayAnimOnKeyUp : MonoBehaviour {

    public GameObject mainObject;
    
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(mainObject, transform.position, transform.rotation);
        }
        
	}
}