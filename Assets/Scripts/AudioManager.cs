using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip WinSound;
    public AudioClip LostSound;
    public AudioClip PuckCollision;
    public AudioClip Goal;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPuckCollision()
    {
        audioSource.PlayOneShot(PuckCollision);
    }

    public void PlayGoal()
    {
        audioSource.PlayOneShot(Goal);
    }

    public void PlayWin()
    {
        audioSource.PlayOneShot(WinSound);
    }

    public void PlayLost()
    {
        audioSource.PlayOneShot(LostSound);
    }
}
