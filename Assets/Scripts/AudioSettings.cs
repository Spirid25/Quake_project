using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetMaster(float value)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }

    public void SetFire(float value)
    {
        mixer.SetFloat("FireVolume", Mathf.Log10(value) * 20);
    }
}