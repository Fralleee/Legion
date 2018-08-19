using UnityEngine;
using System.Collections;

public class AnimationEvents : MonoBehaviour {

    public SceneManagerv2_Jinx MainSceneManager;
    public Animator MainTarget;
    public Animator Minion_01;
    public Animator Minion_02;
    public Animator Minion_03;
    public GameObject Invocation_01;

    private float randomVO_Chosen = 0;

    // Use this for initialization
    void Start () {
        //MainSceneManager = GameObject.Find("_SceneManager").GetComponent<SceneManagerv2_Jinx>;
        //Invocation_01.SetActive(false);

    }



    public void ApplyPassiveFX()
    {
        if (MainSceneManager.spellsApplyPassive == true)
        {
            MainSceneManager.passiveEffect_1.Stop();
            MainSceneManager.passiveEffect_1.Play();
            MainSceneManager.passiveCurrentDuration = MainSceneManager.passiveDuration;

            //Debug.Log(MainSceneManager.passiveCurrentDuration);

        }
    }
    
    public void ProcPassiveFX()
    {
        if (MainSceneManager.passiveCurrentDuration != 0)
        {
            MainSceneManager.passiveCurrentDuration = 0;
            MainSceneManager.passiveEffect_1.Stop();
            MainSceneManager.passiveHitEffect_1.Play();
            MainSceneManager.passiveProcSound_1.Play();
            //Debug.Log(MainSceneManager.passiveCurrentDuration);
        }
    }

    public void ReactivateSpell_E()
    {
        if (MainSceneManager.canReactive_E == true)
        {

        }
    }

    public void ActivateSpell_E_Charge() {
        
        // If we are launching the spell for the first time
        if (MainSceneManager.isE_Launched == false && MainSceneManager.canReactive_E == true)
        {
            if (MainSceneManager.EHasSounds == true)
            {
                MainSceneManager.E_ChargeSound.Play();
            }
            MainSceneManager.E_CurrentTime = MainSceneManager.E_MaximumTime;
            MainSceneManager.E_Explosion.SetActive(false);
            MainSceneManager.isE_Launched = true;
            MainSceneManager.E_Charge.SetActive(true);

            //StartCoroutine(MainSceneManager.E_Countdown());
        }
    }

    public void ActivateSpell_R_Shoot()
    {

        // If we are launching the spell for the first time
        if (MainSceneManager.isR_Launched == false && MainSceneManager.canReactive_R == true)
        {
            //MainSceneManager.R_ChargeSound.Play();
            MainSceneManager.R_CurrentTime = MainSceneManager.R_MaximumTime;
            //MainSceneManager.R_Explosion.SetActive(false);
            MainSceneManager.isR_Launched = true;
            //MainSceneManager.R_Charge.SetActive(true);

            //StartCoroutine(MainSceneManager.E_Countdown());
        }
    }

    public void KillTarget(int TargetNumber)
    {
        switch (TargetNumber) {

            case 1:
                MainTarget.SetTrigger("Death");
                break;
            case 2:
                Minion_01.SetTrigger("Death");
                break;
            case 3:
                Minion_02.SetTrigger("Death");
                break;
            case 4:
                Minion_03.SetTrigger("Death");
                break;
        }
    }


    public void ApplyVisionFX()
    {
        if (MainSceneManager.spellsApplyVision == true)
        {
            MainSceneManager.visionEffect_1.Stop();
            MainSceneManager.visionEffect_1.Play();
            MainSceneManager.visionCurrentDuration = MainSceneManager.visionDuration;

            //Debug.Log(MainSceneManager.passiveCurrentDuration);

        }
    }

    public void PlayRecallFX()
    {
            MainSceneManager.recallFX.Play();
    }


    public void PlayIdleFX()
    {
        MainSceneManager.idleFX.Play();
    }

    public void PlaySound(int soundToPlay)
    {
        MainSceneManager.SFX[soundToPlay-1].Play();

    }

    public void PlayVO_Random(string type)
    {
        if (MainSceneManager.PlayVO == true)
        {

            randomVO_Chosen = Random.Range(0, 10);

            switch (type)
            {

                case "AA":
                    randomVO_Chosen = Random.Range(0, 10);

                    if (randomVO_Chosen < MainSceneManager.VO_AA_Rand && GetComponent<AudioSource>().isPlaying == false)
                    {
                        GetComponent<AudioSource>().clip = MainSceneManager.VO_AA[Random.Range(0, MainSceneManager.VO_AA.Length)];
                        GetComponent<AudioSource>().Play();
                    }
                    break;
                case "Q":
                    randomVO_Chosen = Random.Range(0, 10);

                    if (randomVO_Chosen < MainSceneManager.VO_Q_Rand && GetComponent<AudioSource>().isPlaying == false)
                    {
                        GetComponent<AudioSource>().clip = MainSceneManager.VO_Q[Random.Range(0, MainSceneManager.VO_Q.Length)];
                        GetComponent<AudioSource>().Play();
                    }
                    break;

                case "W":
                    randomVO_Chosen = Random.Range(0, 10);

                    if (randomVO_Chosen < MainSceneManager.VO_W_Rand && GetComponent<AudioSource>().isPlaying == false)
                    {
                        GetComponent<AudioSource>().clip = MainSceneManager.VO_W[Random.Range(0, MainSceneManager.VO_W.Length)];
                        GetComponent<AudioSource>().Play();
                    }
                    break;

                case "E":
                    randomVO_Chosen = Random.Range(0, 10);

                    if (randomVO_Chosen < MainSceneManager.VO_E_Rand && GetComponent<AudioSource>().isPlaying == false)
                    {
                        GetComponent<AudioSource>().clip = MainSceneManager.VO_E[Random.Range(0, MainSceneManager.VO_E.Length)];
                        GetComponent<AudioSource>().Play();
                    }
                    break;

                case "R":
                    randomVO_Chosen = Random.Range(0, 10);

                    if (randomVO_Chosen < MainSceneManager.VO_R_Rand && GetComponent<AudioSource>().isPlaying == false)
                    {
                        GetComponent<AudioSource>().clip = MainSceneManager.VO_R[Random.Range(0, MainSceneManager.VO_R.Length)];
                        GetComponent<AudioSource>().Play();
                    }
                    break;

                case "Joke":
                    randomVO_Chosen = Random.Range(0, 10);

                    if (randomVO_Chosen < MainSceneManager.VO_Joke_Rand && GetComponent<AudioSource>().isPlaying == false)
                    {
                        GetComponent<AudioSource>().clip = MainSceneManager.VO_Joke[Random.Range(0, MainSceneManager.VO_Joke.Length)];
                        GetComponent<AudioSource>().Play();
                    }
                    break;

                case "Taunt":
                    randomVO_Chosen = Random.Range(0, 10);

                    if (randomVO_Chosen < MainSceneManager.VO_Taunt_Rand && GetComponent<AudioSource>().isPlaying == false)
                    {
                        GetComponent<AudioSource>().clip = MainSceneManager.VO_Taunt[Random.Range(0, MainSceneManager.VO_Taunt.Length)];
                        GetComponent<AudioSource>().Play();
                    }
                    break;

                case "Reload":
                    randomVO_Chosen = Random.Range(0, 10);

                    if (randomVO_Chosen < MainSceneManager.VO_Reload_Rand && GetComponent<AudioSource>().isPlaying == false)
                    {
                        GetComponent<AudioSource>().clip = MainSceneManager.VO_Reload[Random.Range(0, MainSceneManager.VO_Reload.Length)];
                        GetComponent<AudioSource>().Play();
                    }
                    break;

            }
        }

    }
    

    public void PlayUniqueVO(int soundToPlay)
    {
        if (MainSceneManager.PlayVO == true)
        {
            randomVO_Chosen = Random.Range(0, 10);

            if (randomVO_Chosen < MainSceneManager.VO_Unique_Rand && GetComponent<AudioSource>().isPlaying == false)
            {
                GetComponent<AudioSource>().clip = MainSceneManager.VO_Unique[soundToPlay - 1];
                GetComponent<AudioSource>().Play();
            }
        }
    }


    public void SpawnInvocation()
    {
        MainSceneManager.invocations = GameObject.FindGameObjectsWithTag("Invocation");
        foreach (GameObject invocation in MainSceneManager.invocations)
        {
            Destroy(invocation);
        }
        Instantiate(Invocation_01);

    }


    public void PassiveChargesIncrement(int decrementCharges)
    {
        MainSceneManager.PassiveCharges = MainSceneManager.PassiveCharges + 1;

        if (MainSceneManager.HasPassiveCharges == true)
        {
            if (decrementCharges == 1)
            {
                // Return Passive at 0 if reaches maximum charges
                if (MainSceneManager.PassiveCharges > MainSceneManager.PassiveChargesMaximum && MainSceneManager.PassiveChargeFX != null)
                {
                    MainSceneManager.PassiveCharges = 0;

                    if (MainSceneManager.HasPassiveChargesStun == true && MainSceneManager.StunFX != null)
                    {
                        MainSceneManager.StunFX.Play();
                    }
                }
            }

            // Activate Passive Charges FX if at max charges
            if (MainSceneManager.PassiveCharges == MainSceneManager.PassiveChargesMaximum && MainSceneManager.PassiveChargeFX != null)
            {
                MainSceneManager.PassiveChargeFX.SetActive(true);
                MainSceneManager.PassiveChargeSound.Play();

            }

            if (decrementCharges == 1)
            {
                // Activate Passive Charges FX if at max charges
                if (MainSceneManager.PassiveCharges < MainSceneManager.PassiveChargesMaximum && MainSceneManager.PassiveChargeFX != null)
                {
                    MainSceneManager.PassiveChargeFX.SetActive(false);
                }
            }
        }
    }

}
