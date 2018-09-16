using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour
{
  ParticleSystem ps;
	void Start ()
	{
	  ps = GetComponent<ParticleSystem>();
    Destroy(gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
  }
}
