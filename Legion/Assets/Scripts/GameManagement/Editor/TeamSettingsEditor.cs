using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TeamSettings))]
public class TeamSettingsEditor : Editor
{
  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    GUI.enabled = Application.isPlaying;
    TeamSettings e = (TeamSettings)target;
    if (GUILayout.Button("Setup")) e.Setup();
  }
}
