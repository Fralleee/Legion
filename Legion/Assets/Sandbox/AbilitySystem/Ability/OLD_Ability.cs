//using System.Collections.Generic;
//using UnityEngine;

//public abstract class Ability : ScriptableObject
//{
//  public Blocker blocker;

//  [Header("Settings")]
//  public int abilityRange = 2;
//  public float cooldown = 2;
//  public float castTime = 1f;
//  public List<AbilityEffect> effects = new List<AbilityEffect>();
//  [Space(10)]

//  [Header("Visuals")]
//  public AnimationTrigger animationTrigger;
//  public ParticleSystem startEffect;
//  public ParticleSystem onCastEffect;
  
//  [HideInInspector] public float lastAction = 0;
//  public GameObject caster { get; set; }
//  public bool isReady { get { return Time.time > lastAction; } }
//  protected int targetLayer;

//  public virtual void Setup(GameObject casterGo, int targetLayerParam)
//  {
//    caster = casterGo;
//    lastAction = 0;
//    targetLayer = targetLayerParam;
//  }

//  public virtual void Cast() { lastAction = Time.time + cooldown; }

//}
