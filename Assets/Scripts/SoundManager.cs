using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip woodSound;
    [SerializeField] private AudioClip stoneSound;
    [SerializeField] private AudioSource audioSource;

    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayWoodSound()
    {
        audioSource.PlayOneShot(woodSound);
    }

    public void PlayStoneSound()
    {
        audioSource.PlayOneShot(stoneSound);
    }
}
