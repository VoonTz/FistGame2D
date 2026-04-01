using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--- Audio Source ---")]
    [SerializeField] AudioSource SFX_Source;

    [Header("--- Audio Clip ---")]
    public AudioClip jump;
    public AudioClip fall;

    public void PlaySFX(AudioClip clip)
    {
        SFX_Source.PlayOneShot(clip); 
    }

}
