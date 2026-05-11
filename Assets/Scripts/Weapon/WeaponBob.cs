using UnityEngine;

public class WeaponBob : MonoBehaviour
{
    public float speed = 8f;
    public float amount = 0.02f;

    float timer;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        float movement = new Vector2(h, v).magnitude;
        movement = Mathf.Clamp01(movement);

        timer += Time.deltaTime * speed * movement;

        float x = Mathf.Cos(timer) * amount;
        float y = Mathf.Sin(timer * 2f) * amount;

        Vector3 offset = new Vector3(x, y, 0) * movement;

        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            startPos + offset,
            Time.deltaTime * 13f
        );
    }
}