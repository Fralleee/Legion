//using UnityEngine;

//#if UNITY_EDITOR
//using UnityEditor;
//[CustomEditor(typeof(TargetAbility), true)]
//public class TargetAbilityEditor : Editor
//{
//  override public void OnInspectorGUI()
//  {
//    base.OnInspectorGUI();
//    TargetAbility targetAbility = (TargetAbility)target;
//    using (var group = new EditorGUILayout.FadeGroupScope(System.Convert.ToSingle(targetAbility.targetReceiver == TargetReceiver.LOCATION)))
//    {
//      if (group.visible)
//      {
//        EditorGUILayout.Space();
//        EditorGUILayout.LabelField("Location Specific", EditorStyles.boldLabel);
//        targetAbility.aoeRadius = EditorGUILayout.FloatField("AOE Radius", targetAbility.aoeRadius);
//        targetAbility.locationEffect = (ParticleSystem)EditorGUILayout.ObjectField("Location Effect", targetAbility.locationEffect, typeof(ParticleSystem), true);
//      }
//    }
//  }
//}

//#endif
