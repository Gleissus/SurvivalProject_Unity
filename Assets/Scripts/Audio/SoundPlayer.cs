using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    //stance private et static
    private static SoundPlayer instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathAudio;
    [SerializeField] private AudioClip collectedItem;
    [SerializeField] private AudioClip hurtPlayer;

    //Acces public a l'instance à traves uns méthode static
    public static SoundPlayer GetInstance() => instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlayDeathAudio()
    {
        audioSource.clip = deathAudio;
        audioSource.Play();
    }

    public void PlayCollectedItemAudio()
    {
        audioSource.clip = collectedItem;
        audioSource.Play();
    }

    public void PlayHurtAudio()
    {
        audioSource.clip = hurtPlayer;
        audioSource.Play();
    }
}
