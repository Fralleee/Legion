using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoAnimManager : MonoBehaviour
{

  [Header("ANIMATORS")]
  public Animator panelAnimator;

  [Header("ANIMATION STRINGS")]
  public string fadeInAnim;
  public string fadeOutAnim;

  [Header("SETTINGS")]
  public string shortcutKey;

  bool isOn;

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
    }
    else if (isOn == false)
    {
      panelAnimator.Play(fadeInAnim);
      isOn = true;
    }
  }
}
