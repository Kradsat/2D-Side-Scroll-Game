using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem instance;

    public AudioSource ApparitionGhostBgm; //bgm monster

    public void Start()
    {
        instance = this;


    }

    public void PlayGhostBGM()
    {
        ApparitionGhostBgm.Play();

    }
  
}
