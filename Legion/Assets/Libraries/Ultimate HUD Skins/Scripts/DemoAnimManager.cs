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

  public bool isOn;
  [SerializeField] BoolVariable isMenuOpen;

  void Update()
  {
    if (Input.GetKeyDown(shortcutKey)) AnimatePanel();
  }

  public void AnimatePanel()
  {
    if (isOn == true)
    {
      panelAnimator.Play(fadeOutAnim);
      isMenuOpen.currentValue = false;
      isOn = false;
    }
    else if (isOn == false)
    {
      panelAnimator.Play(fadeInAnim);
      isMenuOpen.currentValue = true;
      isOn = true;
    }
  }
}
