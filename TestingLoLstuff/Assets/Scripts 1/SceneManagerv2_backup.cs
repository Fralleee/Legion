using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneManagerv2_backup : MonoBehaviour {

    [Header("Particle Systems")]
    public ParticleSystem ParticleSystem_1;
    public ParticleSystem ParticleSystem_2;
    public ParticleSystem ParticleSystem_3;
    public ParticleSystem ParticleSystem_4;

    [Header("Animations")]
    public Animator Animator_1a;
    public Animator Animator_1b;
    public Animator Animator_2a;
    public Animator Animator_2b;
    public Animator Animator_3a;
    public Animator Animator_3b;
    public Animator Animator_4a;
    public Animator Animator_4b;

    [Header("Parameters")]
    public float sceneSpeed = 1;

    [Header("Anim Names")]
    public string SpellQ = "Animation";
    public string SpellW = "Animation";
    public string SpellE = "Animation";
    public string SpellR = "Animation";

    [Header ("GUI")]
    //public Color spriteActivationColor = new Color(0.2f, 0.3f, 0.4f, 1.0f);
    //public Color spriteDeactivationColor = new Color(0.2f, 0.3f, 0.4f, 1.0f);
    //public float abilityFadeDuration = 1.0f;
    public Slider timeSpeed;
    public Text speedText;
    public Text cameraText;
    public Image abilitySprite_Q;
    public Image abilitySprite_W;
    public Image abilitySprite_E;
    public Image abilitySprite_R;

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
        // Update TimeSpeed if changed
        Time.timeScale = timeSpeed.value;
        speedText.text = timeSpeed.value.ToString("0.0");

        // Q Spell
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (ParticleSystem_1 != null)
                ParticleSystem_1.Play();
            if (Animator_1a != null)
                Animator_1a.SetTrigger(SpellQ);
            if (Animator_1b != null)
                Animator_1b.SetTrigger(SpellQ);
        }

        // W Spell
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (ParticleSystem_2 != null)
                ParticleSystem_2.Play();
            if (Animator_2a != null)
                Animator_2a.SetTrigger(SpellW);
            if (Animator_2b != null)
                Animator_2b.SetTrigger(SpellW);
        }

        // E Spell
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (ParticleSystem_3 != null)
                ParticleSystem_3.Play();
            if (Animator_3a != null)
                Animator_3a.SetTrigger(SpellE);
            if (Animator_3b != null)
                Animator_3b.SetTrigger(SpellE);
        }

        // R Spell
        if (Input.GetKeyUp(KeyCode.R))
        {
            if (ParticleSystem_4 != null)
                ParticleSystem_4.Play();
            if (Animator_4a != null)
                Animator_4a.SetTrigger(SpellR);
            if (Animator_4b != null)
                Animator_4b.SetTrigger(SpellR);
        }

        // Faster
        if (Input.GetKeyUp(KeyCode.KeypadPlus))
        {
            timeSpeed.value = timeSpeed.value + 0.1f;
        }

        // Slower
        if (Input.GetKeyUp(KeyCode.KeypadMinus))
        {
            timeSpeed.value = timeSpeed.value - 0.1f;
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
}
