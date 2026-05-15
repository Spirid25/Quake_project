using UnityEngine;

public class WeapoonHandler : MonoBehaviour
{
    public Camera weaponCamera;
    public LayerMask weaponLayer;
    public float weaponFOV = 35f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = GetComponent<Camera>();

        if (weaponCamera != null)
        {
            weaponCamera.clearFlags = CameraClearFlags.Depth;
            weaponCamera.cullingMask = weaponLayer;
            weaponCamera.fieldOfView = weaponFOV;

            weaponCamera.transform.SetParent(mainCamera.transform);
            weaponCamera.transform.localPosition = Vector3.zero;
            weaponCamera.transform.localRotation = Quaternion.identity;
        }
    }

    void Update()
    {
        if (weaponCamera != null)
        {
            weaponCamera.fieldOfView = weaponFOV;
        }
    }
}