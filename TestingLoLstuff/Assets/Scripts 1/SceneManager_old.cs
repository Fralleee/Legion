using UnityEngine;
using System.Collections;

public class SceneManager_old : MonoBehaviour {

    [Header("Particle Systems")]
    public ParticleSystem ParticleSystem_1;
    public ParticleSystem ParticleSystem_2;
    public ParticleSystem ParticleSystem_3;
    public ParticleSystem ParticleSystem_4;

    [Header("Animations")]
    public Animation Animation_1a;
    public Animation Animation_1b;
    public Animation Animation_1c;
    public Animation Animation_2a;
    public Animation Animation_2b;
    public Animation Animation_2c;
    public Animation Animation_3a;
    public Animation Animation_3b;
    public Animation Animation_3c;
    public Animation Animation_4a;
    public Animation Animation_4b;
    public Animation Animation_4c;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Q))
        {
            ParticleSystem_1.Play();
            Animation_1a.Play();
            Animation_1b.Play();
            Animation_1c.Play();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            ParticleSystem_2.Play();
            Animation_2a.Play();
            Animation_2b.Play();
            Animation_2c.Play();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            ParticleSystem_3.Play();
            Animation_3a.Play();
            Animation_3b.Play();
            Animation_3c.Play();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            ParticleSystem_4.Play();
            Animation_4a.Play();
            Animation_4b.Play();
            Animation_4c.Play();
        }

    }
}
