using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    [Header("Source")]
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource SFX;

    [Header("Clip -- BGM")]
    [SerializeField] private AudioClip bgmClip;

    [Header("Clip -- SFX")]
    [SerializeField] private AudioClip walking;


    public void PlayBGM(AudioClip bgm)
    {
        if(bgm == null || BGM == null) return;
        BGM.clip = bgm;
        BGM.loop = true;
        BGM.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null || SFX == null) return;
        SFX.PlayOneShot(clip);
    }
}
