using UnityEngine;
using UnityEngine.Events;

public class AnimationEvents : MonoBehaviour
{
  [SerializeField] UnityEvent evt;
  void ApplyForce()
  {
    evt.Invoke();
  }
}
