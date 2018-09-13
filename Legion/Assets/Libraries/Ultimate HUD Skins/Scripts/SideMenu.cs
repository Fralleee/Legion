using UnityEngine;

public class SideMenu : MonoBehaviour
{

  [Header("ANIMATORS")]
  public Animator sideMenuAnimator;

  const string menuOpening = "Side Menu Opening";
  const string menuClosing = "Side Menu Closing";

  [Header("VARIABLES")]
  public bool isOpen;

  void Start()
  {
    if (isOpen)
      sideMenuAnimator.Play(menuOpening);
    else
      Debug.Log("Side Menu Closed");
  }

  public void OpenClose()
  {
    if (isOpen)
    {
      sideMenuAnimator.Play(menuClosing);
      isOpen = false;
    }

    else
    {
      sideMenuAnimator.Play(menuOpening);
      isOpen = true;
    }
  }
}