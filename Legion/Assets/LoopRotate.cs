using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopRotate : MonoBehaviour
{
  [SerializeField] float speed = 90f;
	void Update ()
	{
	  transform.Rotate(0, 0, speed * Time.deltaTime);
  }
}
