using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHandler : MonoBehaviour
{


  [Header("PANEL LIST")]
  public List<GameObject> panels = new List<GameObject>();

  [Header("BUTTON LIST")]
  public List<GameObject> buttons = new List<GameObject>();

  [Header("PANEL ANIMS")]
  public string panelFadeIn = "Panel Open";
  public string panelFadeOut = "Panel Close";

  [Header("BUTTON ANIMS")]
  public string buttonFadeIn = "TP Open";
  public string buttonFadeOut = "TP Close";

  GameObject currentPanel;
  GameObject nextPanel;
  GameObject currentButton;
  GameObject nextButton;

  [Header("SETTINGS")]
  public int currentPanelIndex;
  int currentButtonlIndex;

  Animator currentPanelAnimator;
  Animator nextPanelAnimator;
  Animator currentButtonAnimator;
  Animator nextButtonAnimator;

  void Start()
  {
    if (buttons.Count > 0)
    {
      currentButton = buttons[currentButtonlIndex];
      currentButtonAnimator = currentButton.GetComponent<Animator>();
      currentButtonAnimator.Play(buttonFadeIn);
    }
  }

  public void PanelAnim(int newPanel)
  {
    if (newPanel != currentPanelIndex)
    {
      currentPanel = panels[currentPanelIndex];
      currentPanelIndex = newPanel;
      nextPanel = panels[currentPanelIndex];
      currentPanelAnimator = currentPanel.GetComponent<Animator>();
      nextPanelAnimator = nextPanel.GetComponent<Animator>();
      currentPanelAnimator.Play(panelFadeOut);
      nextPanelAnimator.Play(panelFadeIn);

      if (buttons.Count > 0)
      {
        currentButton = buttons[currentButtonlIndex];
        currentButtonlIndex = newPanel;
        nextButton = buttons[currentButtonlIndex];
        currentButtonAnimator = currentButton.GetComponent<Animator>();
        nextButtonAnimator = nextButton.GetComponent<Animator>();
        currentButtonAnimator.Play(buttonFadeOut);
        nextButtonAnimator.Play(buttonFadeIn);
      }
    }
  }
}
