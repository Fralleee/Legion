using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portrait : MonoBehaviour
{
  Transform character;
  GameObject currentModel;

  void Awake()
  {
    character = transform.FindDeepChild("Character");
  }

  public void SetupPortrait(Target target)
  {
    if(currentModel)
    {
      Destroy(currentModel);
      currentModel = null;
    }
    currentModel = Instantiate(target.gameObject, character.transform.position, Quaternion.identity, character);
    Component[] components = currentModel.GetComponents(typeof(Component));
    foreach (Component comp in components)
    {
      if (comp is Transform) continue;
      Destroy(comp);
    }
  }
}
