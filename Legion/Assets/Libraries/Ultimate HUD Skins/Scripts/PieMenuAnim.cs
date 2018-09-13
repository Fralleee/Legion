using UnityEngine;

public class PieMenuAnim : MonoBehaviour {

    [Header("ANIMATORS")]
    public Animator panelAnimator;

    [Header("ANIMATION STRINGS")]
    public string fadeInAnim;
    public string fadeOutAnim;

    [Header("SETTINGS")]
    public string shortcutKey;

  bool isOn;
  bool isHolding;

  void Update()
    {

        if (Input.GetKey(shortcutKey))
        {
            isHolding = true;
            isOn = false;
        }
        else
        {
            isHolding = false;
            isOn = true;
        }

        if (isOn && isHolding == false)
        {
            panelAnimator.Play(fadeOutAnim);
            isHolding = false;
            isOn = false;
        }
        else if (isOn == false && isHolding)
        {
            panelAnimator.Play(fadeInAnim);
            isHolding = true;
        }
    }

    public void AnimatePanel ()
    {
        if (isOn)
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
