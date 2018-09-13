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

  public BoolVariable isMenuOpen;

  void Update()
  {
    if (Input.GetKeyDown(shortcutKey)) AnimatePanel();
  }

  public void AnimatePanel()
  {
    if (isMenuOpen.currentValue)
    {
      panelAnimator.Play(fadeOutAnim);
      isMenuOpen.currentValue = false;
    }
    else
    {
      panelAnimator.Play(fadeInAnim);
      isMenuOpen.currentValue = true;
    }
  }
}
