using Fralle;
using UnityEngine;

public class StartRound : MonoBehaviour
{
  [SerializeField] GameEvent onRoundStart;
  void Start()
  {
    onRoundStart.Raise();
  }
}
