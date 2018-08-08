using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Abilities/Target")]
public class TargetAbility : Ability
{
  [Header("Target Ability Specific")]
  public TargetReceiver targetReceiver = TargetReceiver.TARGET;
  [HideInInspector] public float aoeRadius = 1; // Only applicable if targetlocation
  [HideInInspector] public GameObject locationEffect; // Only applicable if targetlocation

  public override void Setup(GameObject caster) { base.Setup(caster); }
  public override void Cast(GameObject target)
  {
    base.Cast(target);
    switch (targetReceiver)
    {
      case TargetReceiver.TARGET:
        TargetCast(target);
        break;
      case TargetReceiver.LOCATION:
        throw new NotImplementedException();
      //LocationCast(target.transform.position);
      default:
        TargetCast(target);
        break;
    }
  }

  void TargetCast(GameObject target)
  {
    DamageController damageController = target.GetComponent<DamageController>();
    if (damageController != null)
    {
      var rnd = new System.Random();
      int amount = rnd.Next(MinAmount, MaxAmount);
      damageController.TakeDamage(amount, Caster, AbilityName);
    }
  }

}

#if UNITY_EDITOR
[CustomEditor(typeof(TargetAbility))]
public class TargetAbilityEditor : Editor
{

  override public void OnInspectorGUI()
  {
    DrawDefaultInspector();
    TargetAbility targetAbility = (TargetAbility)target;

    using (var group = new EditorGUILayout.FadeGroupScope(System.Convert.ToSingle(targetAbility.targetReceiver == TargetReceiver.LOCATION)))
    {
      if (group.visible)
      {
        targetAbility.aoeRadius = EditorGUILayout.FloatField("AOE Radius", targetAbility.aoeRadius);
        targetAbility.locationEffect = (GameObject)EditorGUILayout.ObjectField("Location Effect", targetAbility.locationEffect, typeof(GameObject), true);
      }
    }

  }
}
#endif