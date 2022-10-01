using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject prefabMonster;
    public GameObject prefabMonster2;
    public GameObject player;
    private GameObject newInstance;
    public GameObject ghostBGM;
    private GameObject newBgm;
    public float distance = 85f;
    public float distance2 = -85f;
    public Vector3 startingPosition;
    public Count count;
    
  
    // Start is called before the first frame update
    void Start()
    {
        Apparition();
    }

    // Update is called once per frame
    void Update()
    {
        disapear();
        disapearBgm();
    }

    public void Apparition() // instantiate prefab + bgm
    {
        //if (count == 7)
        //{

        //}

        Debug.Log("ghost is here! run bitch!");
        newInstance = Instantiate(prefabMonster, new Vector3( player.transform.position.x - distance, player.transform.position.y, 0), Quaternion.identity);
        newBgm =Instantiate(ghostBGM, new Vector3(0,0,0),Quaternion.identity);
        SoundSystem.instance.PlayGhostBGM();


      //  newInstance = Instantiate(prefabMonster2, new Vector3(player.transform.position.x - distance2, player.transform.position.y, 0), Quaternion.identity);
       
    }
    
    public void disapear() // destroy prefab ghost
    {
        var destroyTime = 10;
        Destroy(newInstance, destroyTime);
    }
    public void disapearBgm() // destroy the bgm
    {
        var destroyTimeBgm = 13;
        Destroy(newBgm, destroyTimeBgm);
    }

    public void checkForEncounter()
    {
        

    }
}
