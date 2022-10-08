using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem instance;

    public AudioSource ApparitionGhostBgm; //bgm monster

    public AudioSource walkingCorridorSE;

    public AudioSource stairDownSE;

    public AudioSource stairUpSE;

    public AudioSource doorOpenSE;

    public AudioSource doorCloseSE;



    public void Start()
    {
        instance = this;


    }

   
    public void PlayGhostBGM()
    {
        ApparitionGhostBgm.Play();
    }
    
    public void PlayStairDownSE()
    {
        stairDownSE.Play();
    }
    public void PlayStairUpSE()
    {
        stairUpSE.Play();
    }
    public void PPlayDoorOpenSE()
    {
        doorOpenSE.Play();
    }
    public void PlayDoorCloseSE()
    {
        doorCloseSE.Play();
    }

    
}
