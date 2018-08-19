using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagerv2_Jinx_backup2 : MonoBehaviour {

    [Header("Particle Systems")]
    public ParticleSystem ParticleSystem_1;
    public ParticleSystem ParticleSystem_2;
    public ParticleSystem ParticleSystem_3;
    public ParticleSystem ParticleSystem_4;

    [Header("Animations")]
    public Animator GlobalAnimator;

    [Header("Parameters")]
    public float sceneSpeed = 1;
    public float lastStep, timeBetweenSteps = 0.5f;
    public float pleaseWaitTimer;
    public int pleaseWaitTime;
    public bool AA_togeable = true;
    public bool AA_toggled = false;

    [Header("Anim Names")]
    public string SpellQ = "Animation";
    public string SpellW = "Animation";
    public string SpellE = "Animation";
    public string SpellR = "Animation";

    public string AA_Anim = "Animation";
    public string AA_Anim_Toggled = "Animation";

    public string SpellQ_1 = "Animation";
    public string SpellQ_2 = "Animation";

    public string SpellQ_Stance1 = "Stance";
    public string SpellQ_Stance2 = "Stance";

    [Header("Cooldowns")]
    public float SpellQ_Cooldown = 4.0f;
    public float SpellW_Cooldown = 4.0f;
    public float SpellE_Cooldown = 4.0f;
    public float SpellR_Cooldown = 4.0f;
    public float AA_Cooldown = 2.0f;

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

    public Sprite availableAbilitySprite;
    public Sprite unavailableAbilitySprite;

    public Text Q_CooldownText;
    public Text W_CooldownText;
    public Text E_CooldownText;
    public Text R_CooldownText;


    [Header("Cameras")]
    public Camera[] cameras;
    private int currentCameraIndex;

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

        AA_CurrentCooldown = Mathf.Clamp(AA_CurrentCooldown - Time.deltaTime, 0, AA_Cooldown);

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
            //abilitySprite_R.color = spriteDeactivationColor;
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
            //abilitySprite_R.color = spriteActivationColor;
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
            }

            if (AA_togeable != true) {

                SpellQ_CurrentCooldown = SpellQ_Cooldown;

                if (ParticleSystem_1 != null)
                    ParticleSystem_1.Play();
                if (GlobalAnimator != null)
                    GlobalAnimator.SetTrigger(SpellQ);
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
        }

        // E Spell
        if (Input.GetKeyUp(KeyCode.E) && SpellE_CurrentCooldown != 0)
            pleaseWaitText.enabled = true;

        if (Input.GetKeyUp(KeyCode.E) && SpellE_CurrentCooldown == 0)
        {
            SpellE_CurrentCooldown = SpellE_Cooldown;

            if (ParticleSystem_3 != null)
                ParticleSystem_3.Play();
            if (GlobalAnimator != null)
                GlobalAnimator.SetTrigger(SpellE);
        }

        // R Spell
        if (Input.GetKeyUp(KeyCode.R) && SpellR_CurrentCooldown != 0)
            pleaseWaitText.enabled = true;

        if (Input.GetKeyUp(KeyCode.R) && SpellR_CurrentCooldown == 0)
        {
            SpellR_CurrentCooldown = SpellR_Cooldown;

            if (ParticleSystem_4 != null)
                ParticleSystem_4.Play();
            if (GlobalAnimator != null)
                GlobalAnimator.SetTrigger(SpellR);
        }

        // Auto Attacks
        if (Input.GetKeyUp(KeyCode.Space) && AA_CurrentCooldown != 0)
            pleaseWaitText.enabled = true;

        if (Input.GetKeyUp(KeyCode.Space) && AA_CurrentCooldown == 0)
        {
            AA_CurrentCooldown = AA_Cooldown;

            // Rocket
            if (AA_toggled == true)
            {
                //if (ParticleSystem_4 != null)
                //    ParticleSystem_4.Play();
                if (GlobalAnimator != null)
                    GlobalAnimator.SetTrigger(AA_Anim_Toggled);
            }

            // Minigun
            if (AA_toggled == false)
            {
                //if (ParticleSystem_4 != null)
                //    ParticleSystem_4.Play();
                if (GlobalAnimator != null)
                    GlobalAnimator.SetTrigger(AA_Anim);
            }
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
