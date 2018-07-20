using UnityEngine;

public class ToggleBuildingButton : MonoBehaviour
{
  [SerializeField] BoolVariable toggleBuildButton;
  GameObject buildButton;

  void Start()
  {
    buildButton = transform.Find("Build Ability").gameObject;
    if (buildButton == null) Debug.LogError("Could not find 'Build Ability' button");
  }

  void Update()
  {
    buildButton.SetActive(toggleBuildButton.currentValue);
  }
}
