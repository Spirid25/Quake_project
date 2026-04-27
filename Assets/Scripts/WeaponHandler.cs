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
            // Настраиваем камеру оружия
            weaponCamera.clearFlags = CameraClearFlags.Depth;
            weaponCamera.cullingMask = weaponLayer;
            weaponCamera.fieldOfView = weaponFOV;

            // Следим за движением основной камеры
            weaponCamera.transform.SetParent(mainCamera.transform);
            weaponCamera.transform.localPosition = Vector3.zero;
            weaponCamera.transform.localRotation = Quaternion.identity;
        }
    }

    void Update()
    {
        if (weaponCamera != null)
        {
            // Синхронизируем FOV если нужно
            weaponCamera.fieldOfView = weaponFOV;
        }
    }
}