using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SoundEffectScript : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip[] audioClip;

    public void PlaySoundEffect(string str)
    {
        audioSource.Stop();
        if(str != "")
        {
            for(int i = 0; i < audioClip.Length; i++)
            {
                if(audioClip[i].name.Contains(str))
                {
                    audioSource.clip = audioClip[i];
                    audioSource.Play();
                }
            }
        }
    }
}
