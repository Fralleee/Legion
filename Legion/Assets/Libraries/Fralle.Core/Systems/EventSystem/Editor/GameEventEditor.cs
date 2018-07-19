using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameEventArgs))]
public class GameEventEditor : Editor
{

  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    GUI.enabled = Application.isPlaying;
    GameEventArgs e = (GameEventArgs)target;
    if (GUILayout.Button("Raise")) e.Raise();
  }

}
