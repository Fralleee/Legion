using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{

  CharacterLaunch characterLaunch;

  void Start()
  {
    characterLaunch = GetComponentInParent<CharacterLaunch>();
  }

  void ApplyForce()
  {
    characterLaunch.ApplyForce();
  }
}
