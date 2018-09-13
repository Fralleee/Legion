using UnityEngine;

public class CameraController : MonoBehaviour
{

  Transform lookAt;
  Transform head;
  bool isLaunching;
  float cacheDistance;

  [SerializeField] float distance = 10f;
  [SerializeField] float cameraSmoothTime = 1f;
  [SerializeField] BoolVariable isMenuOpen;

  Vector3 velocity = Vector3.zero;
  const float Y_ANGLE_MIN = -25f;
  const float Y_ANGLE_MAX = 60f;
  float currentX;
  float currentY;
  int layerMask;
  BlockerController blockerController;
  bool isBlocked { get { return blockerController.ContainsBlocker(camera: true); } }
  bool isActive = true;

  void Start()
  {
    lookAt = GameObject.FindGameObjectWithTag("Player").transform;
    layerMask = 1 << LayerMask.NameToLayer("Environment");
    blockerController = GetComponent<BlockerController>();
  }

  void GatherInput()
  {
    if (isBlocked || isMenuOpen.currentValue) return;
    distance -= Input.GetAxis("Mouse ScrollWheel") * 5;
    currentX += Input.GetAxis("Mouse X");
    currentY -= Input.GetAxis("Mouse Y");
    currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
  }

  void Update()
  {
    GatherInput();
    Vector3 newPosition;
    Vector3 dir = new Vector3(0, 0, -distance);
    Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

    if (isLaunching)
    {
      Vector3 offset = lookAt.transform.right + lookAt.transform.up;
      newPosition = head.position + rotation * dir;
      bool extraSmoothing = (transform.position - newPosition).magnitude > 2;
      float smoothing = extraSmoothing ? 0.15f : cameraSmoothTime;
      transform.position = Vector3.SmoothDamp(transform.position, newPosition + offset, ref velocity, smoothing);
      transform.LookAt(lookAt.position + offset);
    }
    else
    {
      newPosition = lookAt.position + rotation * dir;
      RaycastHit hit;
      if (Physics.Raycast(lookAt.position, newPosition - lookAt.position, out hit, distance, layerMask)) newPosition = hit.point + transform.forward * 0.25f ;
      transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, cameraSmoothTime);
      transform.LookAt(lookAt.position);
    }

    Vector3 direction = lookAt.position - newPosition;
    Quaternion newrotation = Quaternion.Euler(0f, Quaternion.LookRotation(direction).eulerAngles.y, 0f);
    lookAt.transform.rotation = newrotation;
  }

  public void ToggleShoulderLook(Transform newLookAt = null)
  {
    if (newLookAt)
    {
      isLaunching = true;
      head = newLookAt;
      cacheDistance = distance;
      distance = 1.5f;
    }
    else
    {
      isLaunching = false;
      distance = cacheDistance;
    }
  }

}
