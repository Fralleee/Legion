using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InvocationManager : MonoBehaviour {

    public SceneManagerv2_Jinx MainSceneManager;
    private GameObject MainSceneManager_var;
    public float invocationDuration;
    public ParticleSystem spawnFX;
    private float randomVO_Chosen = 0;
    public ParticleSystem SpellE_FX;
    public bool isAlive = true;


    void Start()
    {
        //KillInvocation();
        MainSceneManager_var = GameObject.FindWithTag("SceneManager");
        MainSceneManager = MainSceneManager_var.GetComponent<SceneManagerv2_Jinx>();
        isAlive = true;
    }

    void Update()
    {
        // Kill Invocation
        if (Input.GetKeyUp(KeyCode.Y))
        {
            KillInvocation();
            isAlive = false;
        }

        // AA_1
        if (Input.GetKeyUp(KeyCode.U))
        {
            gameObject.GetComponent<Animator>().SetTrigger("AA");
        }

        // Enrage
        if (Input.GetKeyUp(KeyCode.I))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Enrage");
        }

        // E Spell
        // I deleted the cooldown condition because the main scenemanager script launched the cooldown before this one could verify it.
        if (Input.GetKeyUp(KeyCode.E) && isAlive == true)
        {
            SpellE_FX.Play();
            Debug.Log("SpellE_ShieldTibbers");
        }
    }

    public void PlaySpawnFX()
    {
        spawnFX.Play();
    }

    public void KillInvocation()
    {

        gameObject.GetComponent<Animator>().SetTrigger("Death");
        StartCoroutine(DestroyInvocation());

    }

    public IEnumerator DestroyInvocation() {

        yield return new WaitForSeconds(3.5f);

        this.GetComponent<Animator>().enabled = false;

        //Destroy(gameObject,0.5f);

    }
    


    public void PlaySound_Random(string type)
    {

        randomVO_Chosen = Random.Range(0, 10);

        switch (type)
        {

            case "AA":
                randomVO_Chosen = Random.Range(0, 10);

                if (randomVO_Chosen < MainSceneManager.Invocation_AA_Rand)
                {
                    GetComponent<AudioSource>().clip = MainSceneManager.Invocation_AA[Random.Range(0, MainSceneManager.Invocation_AA.Length)];
                    GetComponent<AudioSource>().Play();
                }
                break;
            case "VO_AA":
                randomVO_Chosen = Random.Range(0, 10);

                if (randomVO_Chosen < MainSceneManager.Invocation_VO_AA_Rand)
                {
                    GetComponent<AudioSource>().clip = MainSceneManager.Invocation_VO_AA[Random.Range(0, MainSceneManager.Invocation_VO_AA.Length)];
                    GetComponent<AudioSource>().Play();
                }
                break;
            case "Q":
                randomVO_Chosen = Random.Range(0, 10);

                if (randomVO_Chosen < MainSceneManager.Invocation_Q_Rand && GetComponent<AudioSource>().isPlaying == false)
                {
                    GetComponent<AudioSource>().clip = MainSceneManager.Invocation_Q[Random.Range(0, MainSceneManager.Invocation_Q.Length)];
                    GetComponent<AudioSource>().Play();
                }
                break;

            case "W":
                randomVO_Chosen = Random.Range(0, 10);

                if (randomVO_Chosen < MainSceneManager.Invocation_W_Rand && GetComponent<AudioSource>().isPlaying == false)
                {
                    GetComponent<AudioSource>().clip = MainSceneManager.Invocation_W[Random.Range(0, MainSceneManager.Invocation_W.Length)];
                    GetComponent<AudioSource>().Play();
                }
                break;

            case "E":
                randomVO_Chosen = Random.Range(0, 10);

                if (randomVO_Chosen < MainSceneManager.Invocation_E_Rand && GetComponent<AudioSource>().isPlaying == false)
                {
                    GetComponent<AudioSource>().clip = MainSceneManager.Invocation_E[Random.Range(0, MainSceneManager.Invocation_E.Length)];
                    GetComponent<AudioSource>().Play();
                }
                break;

            case "R":
                randomVO_Chosen = Random.Range(0, 10);

                if (randomVO_Chosen < MainSceneManager.Invocation_R_Rand && GetComponent<AudioSource>().isPlaying == false)
                {
                    GetComponent<AudioSource>().clip = MainSceneManager.Invocation_R[Random.Range(0, MainSceneManager.Invocation_R.Length)];
                    GetComponent<AudioSource>().Play();
                }
                break;

            case "Death":
                randomVO_Chosen = Random.Range(0, 10);

                if (randomVO_Chosen < MainSceneManager.Invocation_Death_Rand)
                {
                    GetComponent<AudioSource>().clip = MainSceneManager.Invocation_Death[Random.Range(0, MainSceneManager.Invocation_Death.Length)];
                    GetComponent<AudioSource>().Play();
                }
                break;

        }

    }


}


