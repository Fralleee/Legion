using UnityEngine;

public class ToggleBuildingButton : MonoBehaviour
{
  [SerializeField] BoolVariable toggleBuildButton;
  GameObject buildButton;

  void Start()
  {
    buildButton = transform.Find("Build Ability").gameObject;
  }

  void Update()
  {
    buildButton.SetActive(toggleBuildButton.currentValue);
  }
}
