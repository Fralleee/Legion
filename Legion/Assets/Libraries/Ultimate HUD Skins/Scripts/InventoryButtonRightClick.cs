using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButtonRightClick : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IPointerExitHandler
{
    [Header("ANIMATORS")]
    public Animator panelAnimator;

  bool isOpen;

  public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && isOpen == false)
        {
            panelAnimator.Play("Expand");
            isOpen = true;
        }
        else if (eventData.button == PointerEventData.InputButton.Right && isOpen)
        {
            panelAnimator.Play("Minimize");
            isOpen = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && isOpen == false)
        {
            panelAnimator.Play("Expand");
            isOpen = true;
        }
        else if (eventData.button == PointerEventData.InputButton.Right && isOpen)
        {
            panelAnimator.Play("Minimize");
            isOpen = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panelAnimator.Play("Minimize");
        isOpen = false;
    }

    public void TriggerExit()
    {
        panelAnimator.Play("Minimize");
        isOpen = false;
    }
}
