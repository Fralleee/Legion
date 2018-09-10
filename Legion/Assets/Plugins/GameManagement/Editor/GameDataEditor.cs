using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(GameData))]
public class GameDataEditor : Editor
{
  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    GUI.enabled = Application.isPlaying;
    GameData e = (GameData)target;
    if (GUILayout.Button("Next State")) e.NextState();
    if (GUILayout.Button("Victory")) e.Victory();
    if (GUILayout.Button("Defeat")) e.Defeat();
  }

}

#endif
