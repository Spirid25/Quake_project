using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public Transform playerModel;
    public float mouseSensitivity = 500f;

    public float topClamp = -70f;
    public float bottomClamp = 70f;

    public Transform orientation;

    public float leanAmount = 2f;
    public float leanSpeed = 10f;

    float currentLean;

    float pitch;
    float yaw;
    float roll;
    public float recoilReturn = 2f;
    float recoilPitch = 0f;
    float recoilReturnSpeed = 12f;
    public float recoilStrength = 2f;

    void Start()
    {
        Application.targetFrameRate = 60;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        recoilPitch = Mathf.Lerp(recoilPitch, 0, Time.deltaTime * recoilReturnSpeed);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        pitch -= mouseY;
        yaw += mouseX;

        pitch = Mathf.Clamp(pitch, topClamp, bottomClamp);

        float strafe = Input.GetAxis("Horizontal");
        float targetLean = -strafe * leanAmount;

        currentLean = Mathf.Lerp(currentLean, targetLean, Time.deltaTime * leanSpeed);

        roll = currentLean;

        float finalPitch = pitch - recoilPitch;

        transform.rotation = Quaternion.Euler(finalPitch, yaw, roll);

        orientation.rotation = Quaternion.Euler(0, yaw, 0);

        if (playerModel != null)
            playerModel.rotation = Quaternion.Euler(0, yaw, 0);
    }
    public void AddRecoil()
    {
        recoilPitch += recoilStrength;
    }
}
