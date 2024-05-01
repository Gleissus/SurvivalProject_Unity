using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    //stance private et static
    private static SoundPlayer instance;

    [SerializeField] private AudioSource deathAudio;

    //Acces public a l'instance à traves uns méthode static
    public static SoundPlayer GetInstance() => instance;

    private void Awake()
    {
        instance = this;
    }


    public void PlayDeathAudio()
    {
        deathAudio.Play();
    }
}
