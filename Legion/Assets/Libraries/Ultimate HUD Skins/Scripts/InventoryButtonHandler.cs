using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("ANIMATORS")]
    public Animator objectAnimator;

  bool isOpen;

  public void OnPointerEnter(PointerEventData eventData)
    {
        if (isOpen == false)
        {
            objectAnimator.Play("IB Expand");
            isOpen = true;
        }
        else if (isOpen)
        {
            objectAnimator.Play("IB Minimize");
            isOpen = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        objectAnimator.Play("IB Minimize");
        isOpen = false;
    }

    public void TriggerExit()
    {
        objectAnimator.Play("IB Minimize");
        isOpen = false;
    }
}
