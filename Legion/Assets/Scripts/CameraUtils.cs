using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtils : MonoBehaviour
{
  public float zoomInFOV;
  public float smoothingTime;
  float sphereRotation;
  float lerpTimer;
  float initialFOV;
  bool changingFOV;
  bool resettingFOV;

  CameraController cameraController;

  void Start()
  {
    initialFOV = Camera.main.fieldOfView;
    cameraController = GetComponent<CameraController>();
  }

  void Update()
  {
    if (changingFOV) SettingFOV(initialFOV, zoomInFOV);
    if (resettingFOV) SettingFOV(zoomInFOV, initialFOV);
  }

  public void LockRotation()
  {
    cameraController.lockRotation = true;
  }

  public void UnlockRotation()
  {
    cameraController.lockRotation = false;
  }

  public void ChangeFOV()
  {
    changingFOV = true;
    resettingFOV = false;
  }
  public void ResetFOV()
  {
    resettingFOV = true;
    changingFOV = false;
  }

  void SettingFOV(float from, float to)
  {
    lerpTimer += Time.deltaTime / smoothingTime;
    Camera.main.fieldOfView = Mathf.Lerp(from, to, lerpTimer);
    if (lerpTimer >= 1)
    {
      lerpTimer = 0;
      changingFOV = false;
      resettingFOV = false;
    }
  }

}
