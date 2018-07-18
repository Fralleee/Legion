using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Active Ability")]
public class ActiveAbility : ScriptableObject
{
  public Ability ability;
  Ability defaultValue = null;
  void OnEnable() { ability = defaultValue; }
  public GameObject instance { get { return ability ? ability.GetInstance() : null; } }

  public void Activate(Ability a)
  {
    ability = a;
    ability.Initiate(GameObject.Find("Player"));


    // Create particles from ability 
    // i.e. fire particles in hands on player
    // Create cast area indicator
    // same as in building
  }

}
