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

  public GameObject currentPanel;
  GameObject nextPanel;
  GameObject currentButton;
  GameObject nextButton;

  [Header("SETTINGS")]
  public int currentPanelIndex = -1;
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
      if (currentPanelIndex != -1)
      {
        currentPanel = panels[currentPanelIndex];
        currentPanelAnimator = currentPanel.GetComponent<Animator>();
        currentPanelAnimator.Play(panelFadeOut);
      }
      currentPanelIndex = newPanel;
      nextPanel = panels[currentPanelIndex];
      nextPanelAnimator = nextPanel.GetComponent<Animator>();
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

  public void ResetPanels()
  {
    if (nextPanelAnimator) nextPanelAnimator.Play(panelFadeOut);
    currentPanel = null;
    currentPanelIndex = -1;
    nextPanel = null;
    currentPanelAnimator = null;
    nextPanelAnimator = null;
  }
}
