using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFX : MonoBehaviour
{
    public Image damageImage;
    public Image healImage;
    public float fadeSpeed = 2f;

    void Start()
    {
        SetAlpha(damageImage, 0f);
        SetAlpha(healImage, 0f);
    }

    public void DamageFlash()
    {
        StopAllCoroutines();
        StartCoroutine(Flash(damageImage));
    }

    public void HealFlash()
    {
        StopAllCoroutines();
        StartCoroutine(Flash(healImage));
    }

    IEnumerator Flash(Image img)
    {
        SetAlpha(img, 0.6f);

        while (img.color.a > 0f)
        {
            float a = img.color.a - Time.deltaTime * fadeSpeed;
            SetAlpha(img, a);
            yield return null;
        }

        SetAlpha(img, 0f);
    }

    void SetAlpha(Image img, float a)
    {
        Color c = img.color;
        c.a = Mathf.Clamp01(a);
        img.color = c;
    }
}