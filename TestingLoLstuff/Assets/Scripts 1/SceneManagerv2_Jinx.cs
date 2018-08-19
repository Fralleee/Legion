using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagerv2_Jinx : MonoBehaviour {

    [Header("Particle Systems")]
    public ParticleSystem ParticleSystem_1;
    public ParticleSystem ParticleSystem_2;
    public ParticleSystem ParticleSystem_3;
    public ParticleSystem ParticleSystem_4;

    public ParticleSystem recallFX;
    public ParticleSystem idleFX;

    [Header("Passives")]
    public ParticleSystem passiveEffect_1;
    public ParticleSystem passiveHitEffect_1;
    public ParticleSystem visionEffect_1;
    public float passiveDuration;
    public float visionDuration;
    public AudioSource passiveProcSound_1;
    [HideInInspector]
    public float passiveCurrentDuration;
    [HideInInspector]
    public float visionCurrentDuration;

    public bool HasPassiveCharges = false;
    public bool HasPassiveChargesStun = false;
    public int PassiveCharges = 0;
    public int PassiveChargesMaximum = 4;
    public GameObject PassiveChargeFX;
    public AudioSource PassiveChargeSound;
    public ParticleSystem StunFX;

    [Header("Animations")]
    public Animator GlobalAnimator;

    [Header("Parameters")]
    public float sceneSpeed = 1;
    public float lastStep, timeBetweenSteps = 0.5f;
    public float pleaseWaitTimer;
    public int pleaseWaitTime;
    
    public bool canDie = false;
    public bool canRecall = false;
    public bool canKill = false;
    public bool canLaugh = false;
    public bool canDance = false;
    public bool spellsApplyPassive = false;
    public bool spellsApplyVision = false;

    //AA
    [Header("-- AutoAttacks")]
    public bool AA_togeable = true;
    public bool AA_toggled = false;
    public bool AA_cartridge = false;
    public int AA_cartridgeNumber = 0;
    public int AA_cartridgeNumberMax = 4;
    public bool AA_ChargesPassive = false;

    //Q
    [Header("-- Spell Q")]
    public bool Q_ChargesPassive = false;

    //W
    [Header("-- Spell W")]
    public bool W_ChargesPassive = false;

    //E
    [Header("-- Spell E")]
    public bool canReactive_E = false;
    public bool isE_Launched;
    public GameObject E_Charge;
    public GameObject E_Explosion;
    public float E_MaximumTime = 5.0f;
    public float E_CurrentTime = 0.0f;
    public bool EHasSounds = true;
    public AudioSource E_ChargeSound;
    public AudioSource E_ExplosionSound;
    public bool E_ChargesPassive = false;

    //R
    [Header("-- Spell R")]
    public bool canReactive_R = false;
    public bool isR_Launched;
    public GameObject R_Shoot;
    public GameObject R_Hit;
    public GameObject R_ShootFinal;
    public GameObject R_HitFinal;
    public float R_MaximumTime = 10.0f;
    public float R_CurrentTime = 0.0f;
    public int R_NumberOfShots = 0;
    public int R_NumberOfShotsMax = 4;
    public AudioSource R_ShootSound;
    public AudioSource R_HitSound;
    public AudioSource R_ShootFinalSound;
    public AudioSource R_HitFinalSound;
    public bool R_ChargesPassive = false;

    
    [Header("Invocations")]
    public GameObject[] invocations;


    [Header("Triggers References")]
    public AnimationEvents AnimEventsReference;

    public string SpellQ = "Animation";
    public string SpellW = "Animation";
    public string SpellE = "Animation";
    public string SpellR = "Animation";

    public string idleAnim = "Animation";
    public string deathAnim = "Animation";
    public string recallAnim = "Animation";
    public string killAnim = "Animation";
    public string laughAnim = "Animation";
    public string danceAnim = "Animation";

    public string AA_Anim = "Animation";
    public string AA_Anim_Toggled = "Animation";
    
    public string AA_Anim_1 = "Animation";
    public string AA_Anim_2 = "Animation";
    public string AA_Anim_3 = "Animation";
    public string AA_Anim_4 = "Animation";

    public string SpellQ_1 = "Animation";
    public string SpellQ_2 = "Animation";

    public string SpellQ_Stance1 = "Stance";
    public string SpellQ_Stance2 = "Stance";

    public string SpellR_Deploy = "Animation";
    public string SpellR_Idle = "Animation";
    public string SpellR_Shoot = "Animation";
    public string SpellR_ShootLast = "Animation";

    [Header("Cooldowns")]
    public float SpellQ_Cooldown = 4.0f;
    public float SpellW_Cooldown = 4.0f;
    public float SpellE_Cooldown = 4.0f;
    public float SpellR_Cooldown = 11.0f;
    public float AA_Cooldown = 2.0f;
    public float death_Cooldown = 2.0f;
    public float recall_Cooldown = 2.0f;
    public float kill_Cooldown = 2.0f;
    public float laugh_Cooldown = 2.0f;
    public float dance_Cooldown = 2.0f;

    [HideInInspector]
    public float SpellQ_CurrentCooldown = 0.0f;
    [HideInInspector]
    public float SpellW_CurrentCooldown = 0.0f;
    [HideInInspector]
    public float SpellE_CurrentCooldown = 0.0f;
    [HideInInspector]
    public float SpellR_CurrentCooldown = 0.0f;
    [HideInInspector]
    public float AA_CurrentCooldown = 0.0f;
    [HideInInspector]
    public float death_CurrentCooldown = 0.0f;
    [HideInInspector]
    public float recall_CurrentCooldown = 0.0f;
    [HideInInspector]
    public float kill_CurrentCooldown = 0.0f;
    [HideInInspector]
    public float laugh_CurrentCooldown = 0.0f;
    [HideInInspector]
    public float dance_CurrentCooldown = 0.0f;

    [Header ("GUI")]
    public Color spriteActivationColor = new Color(0.2f, 0.3f, 0.4f, 1.0f);
    public Color spriteDeactivationColor = new Color(0.2f, 0.3f, 0.4f, 1.0f);
    public Slider timeSpeed;
    public Text speedText;
    public Text cameraText;
    public Text pleaseWaitText;
    public Image abilitySprite_Q;
    public Image abilitySprite_Q_toggled;
    public Image abilitySprite_W;
    public Image abilitySprite_E;
    public Image abilitySprite_R;

    public Image abilitySprite_Q_Availability;
    public Image abilitySprite_W_Availability;
    public Image abilitySprite_E_Availability;
    public Image abilitySprite_R_Availability;

    public Image abilitySprite_R_InUse;

    public Sprite availableAbilitySprite;
    public Sprite unavailableAbilitySprite;

    public Text Q_CooldownText;
    public Text W_CooldownText;
    public Text E_CooldownText;
    public Text R_CooldownText;

    public GameObject HUD_Map;
    public GameObject HUD_BackgroundRight;
    public GameObject HUD_BackgroundLeft;
    public GameObject HUD_Selection;

    public bool isHUDhidden = false;

    [Header("Cameras")]
    public Camera[] cameras;
    private int currentCameraIndex;

    [Header("Character Sounds")]
    public bool PlayVO = true;
    public AudioSource[] SFX;
    public AudioClip[] VO_AA;
    public float VO_AA_Rand = 3;
    public AudioClip[] VO_Q;
    public float VO_Q_Rand = 3;
    public AudioClip[] VO_W;
    public float VO_W_Rand = 3;
    public AudioClip[] VO_E;
    public float VO_E_Rand = 3;
    public AudioClip[] VO_R;
    public float VO_R_Rand = 3;
    public AudioClip[] VO_Joke;
    public float VO_Joke_Rand = 3;
    public AudioClip[] VO_Taunt;
    public float VO_Taunt_Rand = 3;
    public AudioClip[] VO_Reload;
    public float VO_Reload_Rand = 3;
    //public AudioSource[] VO_Dance;
    //public AudioSource[] VO_Laugh;
    public AudioClip[] VO_Unique;
    public float VO_Unique_Rand = 3;
    
    [Header("Invocations Sounds")]
    public AudioSource[] Invocation_SFX;
    public AudioClip[] Invocation_AA;
    public float Invocation_AA_Rand = 3;
    public AudioClip[] Invocation_VO_AA;
    public float Invocation_VO_AA_Rand = 3;
    public AudioClip[] Invocation_Q;
    public float Invocation_Q_Rand = 3;
    public AudioClip[] Invocation_W;
    public float Invocation_W_Rand = 3;
    public AudioClip[] Invocation_E;
    public float Invocation_E_Rand = 3;
    public AudioClip[] Invocation_R;
    public float Invocation_R_Rand = 3;
    public AudioClip[] Invocation_Death;
    public float Invocation_Death_Rand = 3;
    public AudioClip[] Invocation_Taunt;
    public float Invocation_Taunt_Rand = 3;
    public AudioClip[] Invocation_Reload;
    public float Invocation_Reload_Rand = 3;
    public AudioClip[] Invocation_Unique;
    public float Invocation_Unique_Rand = 3;

    // Use this for initialization
    void Start () {

        Time.timeScale = timeSpeed.value;
        currentCameraIndex = 0;

        //Turn all cameras off, except the first default one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        //If any cameras were added to the controller, enable the first one
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
            cameraText.text = cameras[currentCameraIndex].GetComponent<Camera>().name;
            Debug.Log("Camera with name: " + cameras[0].GetComponent<Camera>().name + ", is now enabled");
        }

    }
	
	// Update is called once per frame
	void Update ()
    {

        pleaseWaitTimer += Time.deltaTime;
        if (pleaseWaitTimer > pleaseWaitTime)
        {
            pleaseWaitText.enabled = false;
            pleaseWaitTimer = 0;
        }

        // Constantly reduce cooldowns
        SpellQ_CurrentCooldown = Mathf.Clamp(SpellQ_CurrentCooldown - Time.deltaTime, 0, SpellQ_Cooldown);
        SpellW_CurrentCooldown = Mathf.Clamp(SpellW_CurrentCooldown - Time.deltaTime, 0, SpellW_Cooldown);
        SpellE_CurrentCooldown = Mathf.Clamp(SpellE_CurrentCooldown - Time.deltaTime, 0, SpellE_Cooldown);
        SpellR_CurrentCooldown = Mathf.Clamp(SpellR_CurrentCooldown - Time.deltaTime, 0, SpellR_Cooldown);

        death_CurrentCooldown = Mathf.Clamp(death_CurrentCooldown - Time.deltaTime, 0, death_Cooldown);
        recall_CurrentCooldown = Mathf.Clamp(death_CurrentCooldown - Time.deltaTime, 0, death_Cooldown);
        kill_CurrentCooldown = Mathf.Clamp(kill_CurrentCooldown - Time.deltaTime, 0, kill_Cooldown);
        laugh_CurrentCooldown = Mathf.Clamp(laugh_CurrentCooldown - Time.deltaTime, 0, laugh_Cooldown);
        dance_CurrentCooldown = Mathf.Clamp(dance_CurrentCooldown - Time.deltaTime, 0, dance_Cooldown);

        AA_CurrentCooldown = Mathf.Clamp(AA_CurrentCooldown - Time.deltaTime, 0, AA_Cooldown);

        passiveCurrentDuration = Mathf.Clamp(passiveCurrentDuration - Time.deltaTime, 0, passiveDuration);

        E_CurrentTime = Mathf.Clamp(E_CurrentTime - Time.deltaTime, 0, E_MaximumTime);
        R_CurrentTime = Mathf.Clamp(R_CurrentTime - Time.deltaTime, 0, R_MaximumTime);

        
        // Grey out the abilities on Cooldown
        if (SpellQ_CurrentCooldown != 0)
        {
            Q_CooldownText.enabled = true;
            Q_CooldownText.text = SpellQ_CurrentCooldown.ToString("0.0.0");

            //abilitySprite_Q.enabled = true;

            abilitySprite_Q_Availability.sprite = unavailableAbilitySprite;

            abilitySprite_Q.color = spriteDeactivationColor;
            if (abilitySprite_Q_toggled != null)
                abilitySprite_Q_toggled.color = spriteDeactivationColor;
        }

        if (SpellW_CurrentCooldown != 0)
        {

            abilitySprite_W_Availability.sprite = unavailableAbilitySprite;

            W_CooldownText.enabled = true;
            W_CooldownText.text = SpellW_CurrentCooldown.ToString("0.0.0");
            abilitySprite_W.color = spriteDeactivationColor;
        }

        if (SpellE_CurrentCooldown != 0)
        {

            abilitySprite_E_Availability.sprite = unavailableAbilitySprite;

            E_CooldownText.enabled = true;
            E_CooldownText.text = SpellE_CurrentCooldown.ToString("0.0.0");
            abilitySprite_E.color = spriteDeactivationColor;
        }

        if (SpellR_CurrentCooldown != 0)
        {

            abilitySprite_R_Availability.sprite = unavailableAbilitySprite;

            R_CooldownText.enabled = true;
            R_CooldownText.text = SpellR_CurrentCooldown.ToString("0.0.0");
            abilitySprite_R.color = spriteDeactivationColor;
        }

        if (AA_CurrentCooldown != 0)
        {
            //abilitySprite_AA.color = spriteDeactivationColor;
        }

        if (death_CurrentCooldown != 0)
        {
            //abilitySprite_death.color = spriteDeactivationColor;
        }

        if (recall_CurrentCooldown != 0)
        {
            //abilitySprite_death.color = spriteDeactivationColor;
        }

        if (kill_CurrentCooldown != 0)
        {
            //abilitySprite_death.color = spriteDeactivationColor;
        }

        if (laugh_CurrentCooldown != 0)
        {
            //abilitySprite_death.color = spriteDeactivationColor;
        }

        if (dance_CurrentCooldown != 0)
        {
            //abilitySprite_death.color = spriteDeactivationColor;
        }

        // Light the available abilities
        if (SpellQ_CurrentCooldown == 0)
        {
            abilitySprite_Q_Availability.sprite = availableAbilitySprite;

            Q_CooldownText.enabled = false;

            abilitySprite_Q.color = spriteActivationColor;
            if (abilitySprite_Q_toggled != null)
                abilitySprite_Q_toggled.color = spriteActivationColor;
        }

        if (SpellW_CurrentCooldown == 0)
        {
            abilitySprite_W_Availability.sprite = availableAbilitySprite;

            W_CooldownText.enabled = false;
            abilitySprite_W.color = spriteActivationColor;
        }

        if (SpellE_CurrentCooldown == 0)
        {
            abilitySprite_E_Availability.sprite = availableAbilitySprite;

            E_CooldownText.enabled = false;
            abilitySprite_E.color = spriteActivationColor;
        }

        if (SpellR_CurrentCooldown == 0)
        {
            abilitySprite_R_Availability.sprite = availableAbilitySprite;

            R_CooldownText.enabled = false;
            abilitySprite_R.color = spriteActivationColor;
        }


        if (AA_CurrentCooldown == 0)
        {
            //abilitySprite_AA.color = spriteActivationColor;
        }

        if (death_CurrentCooldown == 0)
        {
            //abilitySprite_death.color = spriteActivationColor;
        }

        if (recall_CurrentCooldown == 0)
        {
            //abilitySprite_death.color = spriteActivationColor;
        }

        if (kill_CurrentCooldown == 0)
        {
            //abilitySprite_death.color = spriteActivationColor;
        }

        if (laugh_CurrentCooldown == 0)
        {
            //abilitySprite_death.color = spriteActivationColor;
        }

        if (dance_CurrentCooldown == 0)
        {
            //abilitySprite_death.color = spriteActivationColor;
        }

        // E Reactivation
        if (E_CurrentTime == 0 && isE_Launched == true)
        {

            if (EHasSounds == true)
            {
                E_ExplosionSound.Play();
                E_ChargeSound.Stop();
            }
            E_Explosion.SetActive(true);
            E_Charge.SetActive(false);
            isE_Launched = false;

            if (spellsApplyPassive == true)
            {
                AnimEventsReference.ApplyPassiveFX();
            }

            E_CurrentTime = 0;

            // Start Cooldown
            SpellE_CurrentCooldown = SpellE_Cooldown;
        }

        // If R runs out of time
        if (R_CurrentTime == 0 && isR_Launched == true)
        {
            // Return to Idle
            R_NumberOfShots = 0;
            R_CurrentTime = 0;
            isR_Launched = false;
            //SpellR_CurrentCooldown = SpellR_Cooldown;
            GlobalAnimator.SetTrigger(idleAnim);
            Debug.Log("Reset");
            abilitySprite_R_Availability.enabled = true;
            abilitySprite_R_InUse.enabled = false;
        }

        // Update TimeSpeed if changed
        Time.timeScale = timeSpeed.value;
        speedText.text = timeSpeed.value.ToString("0.0.0");

        // Q Spell
        if (Input.GetKeyUp(KeyCode.Q) && SpellQ_CurrentCooldown != 0)
            pleaseWaitText.enabled = true;
        if (Input.GetKeyUp(KeyCode.Q) && SpellQ_CurrentCooldown == 0)
        {
            if (AA_togeable == true)
            {
                AA_toggled = !AA_toggled;
                SpellQ_CurrentCooldown = SpellQ_Cooldown;

                if (HasPassiveCharges == true)
                {
                    if (Q_ChargesPassive == true)
                    {
                        PassiveCharges = PassiveCharges + 1;
                    }
                }
            }

            if (AA_togeable != true) {

                SpellQ_CurrentCooldown = SpellQ_Cooldown;

                if (ParticleSystem_1 != null)
                    ParticleSystem_1.Play();
                if (GlobalAnimator != null)
                    GlobalAnimator.SetTrigger(SpellQ);

                if (HasPassiveCharges == true)
                {
                    if (Q_ChargesPassive == true)
                    {
                        PassiveCharges = PassiveCharges + 1;
                    }
                }
            }

            // In Jinx case, if in Minigun Stance
            if (AA_toggled == false && AA_togeable == true)
            {
                GlobalAnimator.SetBool(SpellQ_Stance1, true);
                GlobalAnimator.SetBool(SpellQ_Stance2, false);

                abilitySprite_Q.enabled = true;
                if (abilitySprite_Q_toggled != null)
                    abilitySprite_Q_toggled.enabled = false;

                //SpellQ_CurrentCooldown = SpellQ_Cooldown;

                if (ParticleSystem_1 != null)
                    ParticleSystem_1.Play();
                if (GlobalAnimator != null)
                    GlobalAnimator.SetTrigger(SpellQ_2);

                if (HasPassiveCharges == true)
                {
                    if (Q_ChargesPassive == true)
                    {
                        PassiveCharges = PassiveCharges + 1;
                    }
                }
            }

            // In Jinx case, if in RocketLauncher Stance
            if (AA_toggled == true && AA_togeable == true)
            {
                GlobalAnimator.SetBool(SpellQ_Stance2, true);
                GlobalAnimator.SetBool(SpellQ_Stance1, false);

                abilitySprite_Q.enabled = false;
                if (abilitySprite_Q_toggled != null)
                    abilitySprite_Q_toggled.enabled = true;

                //SpellQ_CurrentCooldown = SpellQ_Cooldown;

                if (ParticleSystem_1 != null)
                    ParticleSystem_1.Play();
                if (GlobalAnimator != null)
                    GlobalAnimator.SetTrigger(SpellQ_1);

                if (HasPassiveCharges == true)
                {
                    if (Q_ChargesPassive == true)
                    {
                        PassiveCharges = PassiveCharges + 1;
                    }
                }
            }
        }

        // W Spell
        if (Input.GetKeyUp(KeyCode.W) && SpellW_CurrentCooldown != 0)
            pleaseWaitText.enabled = true;

        if (Input.GetKeyUp(KeyCode.W) && SpellW_CurrentCooldown == 0)
        {
            SpellW_CurrentCooldown = SpellW_Cooldown;

            if (ParticleSystem_2 != null)
                ParticleSystem_2.Play();
            if (GlobalAnimator != null)
                GlobalAnimator.SetTrigger(SpellW);

            if (HasPassiveCharges == true)
            {
                if (W_ChargesPassive == true)
                {
                    PassiveCharges = PassiveCharges + 1;
                }
            }
        }

        // E Spell
        if (Input.GetKeyUp(KeyCode.E) && SpellE_CurrentCooldown != 0)
            pleaseWaitText.enabled = true;

        if (Input.GetKeyUp(KeyCode.E) && SpellE_CurrentCooldown == 0)
        {

            // If this is a normal spell
            if (canReactive_E == false)
            {
                if (ParticleSystem_3 != null)
                    ParticleSystem_3.Play();
                if (GlobalAnimator != null)
                    GlobalAnimator.SetTrigger(SpellE);

                // Start Cooldown
                SpellE_CurrentCooldown = SpellE_Cooldown;

                if (HasPassiveCharges == true)
                {
                    if (E_ChargesPassive == true)
                    {
                        PassiveCharges = PassiveCharges + 1;
                    }
                }
            }

            // If we can reactivate the spell
            if (canReactive_E == true)
            {
                // If the spell isn't already cast
                if (isE_Launched == false)
                {
                    if (ParticleSystem_3 != null)
                        ParticleSystem_3.Play();
                    if (GlobalAnimator != null)
                        GlobalAnimator.SetTrigger(SpellE);

                    E_Explosion.SetActive(false);

                    if (HasPassiveCharges == true)
                    {
                        if (E_ChargesPassive == true)
                        {
                            PassiveCharges = PassiveCharges + 1;
                        }
                    }
                }

                // If the spell is already cast
                if (isE_Launched == true)
                {
                    if (EHasSounds == true)
                    {
                        E_ExplosionSound.Play();
                        E_ChargeSound.Stop();
                    }
                    E_Explosion.SetActive(true);
                    E_Charge.SetActive(false);
                    isE_Launched = false;

                    if (spellsApplyPassive == true)
                    {
                        AnimEventsReference.ApplyPassiveFX();
                    }

                    E_CurrentTime = 0;

                    // Start Cooldown
                    SpellE_CurrentCooldown = SpellE_Cooldown;
                }
            }
            
        }

        // R Spell
        if (Input.GetKeyUp(KeyCode.R) && SpellR_CurrentCooldown != 0)
            pleaseWaitText.enabled = true;

        if (Input.GetKeyUp(KeyCode.R) && SpellR_CurrentCooldown == 0)
        {

            // If this is a normal spell
            if (canReactive_R == false)
            {
                if (ParticleSystem_4 != null)
                    ParticleSystem_4.Play();
                if (GlobalAnimator != null)
                    GlobalAnimator.SetTrigger(SpellR);
                
                SpellR_CurrentCooldown = SpellR_Cooldown;

                if (HasPassiveCharges == true)
                {
                    if (R_ChargesPassive == true)
                    {
                        PassiveCharges = PassiveCharges + 1;
                    }
                }
            }

            // If we can reactivate the spell
            if (canReactive_R == true)
            {
                // If the spell isn't already cast, deploy the R
                if (isR_Launched == false)
                {
                    if (ParticleSystem_4 != null)
                        ParticleSystem_4.Play();
                    if (GlobalAnimator != null)
                        GlobalAnimator.SetTrigger(SpellR_Deploy);

                    abilitySprite_R_Availability.enabled = false;
                    abilitySprite_R_InUse.enabled = true;

                    R_NumberOfShots = R_NumberOfShotsMax;

                    isR_Launched = true;
                    R_CurrentTime = R_MaximumTime;

                    if (HasPassiveCharges == true)
                    {
                        if (R_ChargesPassive == true)
                        {
                            PassiveCharges = PassiveCharges + 1;
                        }
                    }

                    // Start Cooldown
                    //SpellR_CurrentCooldown = SpellR_Cooldown;

                    //R_Hit.SetActive(false);
                }

                // If the spell is already cast
                if (isR_Launched == true)
                {
                    // If we are on the last shot
                    if (R_NumberOfShots == 1)
                    {
                        isR_Launched = false;

                        // Do the big shot
                        GlobalAnimator.SetTrigger(SpellR_ShootLast);

                        /*if (spellsApplyPassive == true)
                        {
                            AnimEventsReference.ApplyPassiveFX();
                        }*/

                        abilitySprite_R_Availability.enabled = true;
                        abilitySprite_R_InUse.enabled = false;

                        Debug.Log("Shot Last");
                    }

                    // If we still have normal bullets
                    if (isR_Launched == true && R_NumberOfShots > 1 && R_CurrentTime < (R_MaximumTime-0.5f))
                    {
                        GlobalAnimator.SetTrigger(SpellR_Shoot);
                        /*R_Hit.SetActive(true);
                        R_HitSound.Play();
                        R_ShootSound.Stop();
                        R_Shoot.SetActive(false);
                        isE_Launched = false;*/

                        /*if (spellsApplyPassive == true)
                        {
                            AnimEventsReference.ApplyPassiveFX();
                        }*/

                        //R_CurrentTime = 0;
                        R_NumberOfShots = R_NumberOfShots - 1;
                        Debug.Log("Shot");
                    }

                }
            }
            
        }

        // Auto Attacks
        if (Input.GetKeyUp(KeyCode.Space) && AA_CurrentCooldown != 0)
            pleaseWaitText.enabled = true;

        if (Input.GetKeyUp(KeyCode.Space) && AA_CurrentCooldown == 0)
        {
            AA_CurrentCooldown = AA_Cooldown;

            if (AA_togeable == true)
            {
                // Stance_2
                if (AA_toggled == true)
                {
                    //if (ParticleSystem_4 != null)
                    //    ParticleSystem_4.Play();
                    if (GlobalAnimator != null)
                        GlobalAnimator.SetTrigger(AA_Anim_Toggled);
                }

                // Stance_1
                if (AA_toggled == false)
                {
                    //if (ParticleSystem_4 != null)
                    //    ParticleSystem_4.Play();
                    if (GlobalAnimator != null)
                        GlobalAnimator.SetTrigger(AA_Anim);
                }
            }

            if (AA_cartridge == true)
            {
                //AA_cartridgeNumber = AA_cartridgeNumberMax;

                switch (AA_cartridgeNumber)
                {
                    case 1:
                        GlobalAnimator.SetTrigger(AA_Anim_1);
                        Debug.Log("Case1");
                        AA_cartridgeNumber = 2;
                        break;
                    case 2:
                        GlobalAnimator.SetTrigger(AA_Anim_2);
                        Debug.Log("Case2");
                        AA_cartridgeNumber = 3;
                        break;
                    case 3:
                        GlobalAnimator.SetTrigger(AA_Anim_3);
                        Debug.Log("Case3");
                        AA_cartridgeNumber = 4;
                        break;
                    case 4:
                        GlobalAnimator.SetTrigger(AA_Anim_4);
                        Debug.Log("Case4");
                        AA_cartridgeNumber = 1;
                        break;
                }

                if (HasPassiveCharges == true)
                {
                    if (AA_ChargesPassive == true)
                    {
                        PassiveCharges = PassiveCharges + 1;
                    }
                }
            }

            if (AA_cartridge == false && AA_togeable == false)
            {
                if (GlobalAnimator != null)
                    GlobalAnimator.SetTrigger(AA_Anim);
            }

        }
        

        // Death
        if (Input.GetKeyUp(KeyCode.K) && death_CurrentCooldown != 0 && canDie == true)
            pleaseWaitText.enabled = true;

        if (Input.GetKeyUp(KeyCode.K) && death_CurrentCooldown == 0 && canDie == true)
        {
            death_CurrentCooldown = death_Cooldown;


            if (HasPassiveCharges == true) { 
                PassiveCharges = 0;
                PassiveChargeFX.SetActive(false);
            }

            if (GlobalAnimator != null)
                GlobalAnimator.SetTrigger(deathAnim);
        }

        
        // Recall
        if (Input.GetKeyUp(KeyCode.B) && recall_CurrentCooldown != 0 && canRecall == true)
            pleaseWaitText.enabled = true;

        if (Input.GetKeyUp(KeyCode.B) && recall_CurrentCooldown == 0 && canRecall == true)
        {
            recall_CurrentCooldown = recall_Cooldown;

            if (GlobalAnimator != null)
                GlobalAnimator.SetTrigger(recallAnim);
        }


        // Kill Opponent
        if (Input.GetKeyUp(KeyCode.L) && kill_CurrentCooldown != 0 && canKill == true)
            pleaseWaitText.enabled = true;

        if (Input.GetKeyUp(KeyCode.L) && kill_CurrentCooldown == 0 && canKill == true)
        {
            kill_CurrentCooldown = kill_Cooldown;

            if (GlobalAnimator != null)
                GlobalAnimator.SetTrigger(killAnim);
        }


        // Laugh
        if (Input.GetKeyUp(KeyCode.Keypad4) && laugh_CurrentCooldown != 0 && canLaugh == true)
            pleaseWaitText.enabled = true;

        if (Input.GetKeyUp(KeyCode.Keypad4) && laugh_CurrentCooldown == 0 && canLaugh == true)
        {
            laugh_CurrentCooldown = laugh_Cooldown;

            if (GlobalAnimator != null)
                GlobalAnimator.SetTrigger(laughAnim);
        }


        // Dance
        if (Input.GetKeyUp(KeyCode.Keypad3) && dance_CurrentCooldown != 0 && canDance == true)
            pleaseWaitText.enabled = true;

        if (Input.GetKeyUp(KeyCode.Keypad3) && dance_CurrentCooldown == 0 && canDance == true)
        {
            dance_CurrentCooldown = dance_Cooldown;

            if (GlobalAnimator != null)
                GlobalAnimator.SetTrigger(danceAnim);
        }

        // Faster
        if (Input.GetKey(KeyCode.F))
        {
            //if (Time.time - lastStep > timeBetweenSteps)
            //{
            //    lastStep = Time.time;
                timeSpeed.value = timeSpeed.value + 0.05f;
            //}
        }

        // Slower
        if (Input.GetKey(KeyCode.D))
        {
            //if (Time.time - lastStep > timeBetweenSteps)
            //{
            //    lastStep = Time.time;
                timeSpeed.value = timeSpeed.value - 0.05f;
            //}
        }

        // Reset Speed to 1
        if (Input.GetKey(KeyCode.T))
        {
            //if (Time.time - lastStep > timeBetweenSteps)
            //{
            //    lastStep = Time.time;
            timeSpeed.value = 1.0f;
            //}
        }

        // Show/Hide Advanced HUD
        if (Input.GetKeyUp(KeyCode.H))
        {
            if (isHUDhidden == false)
            {
                HUD_BackgroundLeft.SetActive(false);
                HUD_BackgroundRight.SetActive(false);
                HUD_Selection.SetActive(false);
                HUD_Map.SetActive(false);
                isHUDhidden = true;
                Debug.Log("HUD Hidden");
            }
            else if (isHUDhidden == true)
            {
                HUD_BackgroundLeft.SetActive(true);
                HUD_BackgroundRight.SetActive(true);
                HUD_Selection.SetActive(true);
                HUD_Map.SetActive(true);
                isHUDhidden = false;
                Debug.Log("HUD Visible");
            }


        }

        //If the c button is pressed, switch to the next camera
        //Set the camera at the current index to inactive, and set the next one in the array to active
        //When we reach the end of the camera array, move back to the beginning or the array.
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentCameraIndex++;
            Debug.Log("C button has been pressed. Switching to the next camera");
            if (currentCameraIndex < cameras.Length)
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                cameras[currentCameraIndex].gameObject.SetActive(true);
                cameraText.text = cameras[currentCameraIndex].GetComponent<Camera>().name;
                Debug.Log("Camera with name: " + cameras[currentCameraIndex].GetComponent<Camera>().name + ", is now enabled");
            }
            else
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                currentCameraIndex = 0;
                cameras[currentCameraIndex].gameObject.SetActive(true);
                cameraText.text = cameras[currentCameraIndex].GetComponent<Camera>().name;
                Debug.Log("Camera with name: " + cameras[currentCameraIndex].GetComponent<Camera>().name + ", is now enabled");
            }
        }
    }

    public void ChangeScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);
    }

}
