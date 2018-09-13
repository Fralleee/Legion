using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectionAnim : MonoBehaviour {

    public Animator weaponPanelAnimator;
    public List<GameObject> weaponButtons = new List<GameObject>();

  GameObject currentWeapon;
  GameObject selectedWeapon;

  GameObject currentButton;
  GameObject nextButton;

  public int currentButtonIndex;
  int nextButtonIndex;

  Animator currentWeaponAnimator;

  Animator currentButtonAnimator;
  Animator nextButtonAnimator;

  void Start ()
    {
        nextButton = weaponButtons[nextButtonIndex];
        nextButtonAnimator = nextButton.GetComponent<Animator>();
        nextButtonAnimator.Play("WS Fade-in");
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            currentButton = weaponButtons[currentButtonIndex];
            nextButtonIndex = 0;
            nextButton = weaponButtons[nextButtonIndex];

            currentButtonAnimator = currentButton.GetComponent<Animator>();
            currentButtonAnimator.Play("WS Fade-out");

            nextButtonAnimator = nextButton.GetComponent<Animator>();
            nextButtonAnimator.Play("WS Fade-in");
            currentButtonIndex = 0;

            weaponPanelAnimator.Play("WS Fade-in");
        }

        else if (Input.GetKeyDown("2"))
        {
            currentButton = weaponButtons[currentButtonIndex];
            nextButtonIndex = 1;
            nextButton = weaponButtons[nextButtonIndex];

            currentButtonAnimator = currentButton.GetComponent<Animator>();
            currentButtonAnimator.Play("WS Fade-out");

            nextButtonAnimator = nextButton.GetComponent<Animator>();
            nextButtonAnimator.Play("WS Fade-in");
            currentButtonIndex = 1;

            weaponPanelAnimator.Play("WS Fade-in");
        }

        else if (Input.GetKeyDown("3"))
        {
            currentButton = weaponButtons[currentButtonIndex];
            nextButtonIndex = 2;
            nextButton = weaponButtons[nextButtonIndex];

            currentButtonAnimator = currentButton.GetComponent<Animator>();
            currentButtonAnimator.Play("WS Fade-out");

            nextButtonAnimator = nextButton.GetComponent<Animator>();
            nextButtonAnimator.Play("WS Fade-in");
            currentButtonIndex = 2;

            weaponPanelAnimator.Play("WS Fade-in");
        }

        else if (Input.GetKeyDown("4"))
        {
            currentButton = weaponButtons[currentButtonIndex];
            nextButtonIndex = 3;
            nextButton = weaponButtons[nextButtonIndex];

            currentButtonAnimator = currentButton.GetComponent<Animator>();
            currentButtonAnimator.Play("WS Fade-out");

            nextButtonAnimator = nextButton.GetComponent<Animator>();
            nextButtonAnimator.Play("WS Fade-in");
            currentButtonIndex = 3;

            weaponPanelAnimator.Play("WS Fade-in");
        }
    }
}