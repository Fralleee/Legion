using UnityEngine;
using System.Collections;

public class CameraTurntable : MonoBehaviour {

    public GameObject target;
    public float speed = 2.0f;
	
	// Update is called once per frame
	void Update () {

        //Transform.LookAt(target);
        //Transform.Translate(Vector3.right * Time.deltaTime);

        transform.LookAt(target.transform);
        transform.Translate(Vector3.right * Time.deltaTime * speed);


    }
}
