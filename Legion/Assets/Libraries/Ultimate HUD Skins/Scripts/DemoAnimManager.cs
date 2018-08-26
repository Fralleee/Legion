using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoAnimManager : MonoBehaviour
{

  [Header("ANIMATORS")]
  public Animator panelAnimator;
  public PanelHandler panelHandler;

  [Header("ANIMATION STRINGS")]
  public string fadeInAnim;
  public string fadeOutAnim;

  [Header("SETTINGS")]
  public string shortcutKey;

  public bool isOn;

  void Update()
  {
    if (Input.GetKeyDown(shortcutKey)) AnimatePanel();
  }

  public void AnimatePanel()
  {
    if (isOn == true)
    {
      panelAnimator.Play(fadeOutAnim);
      isOn = false;
      panelHandler.ResetPanels();
    }
    else if (isOn == false)
    {
      panelAnimator.Play(fadeInAnim);
      isOn = true;
    }
  }
}
