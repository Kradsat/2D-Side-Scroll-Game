using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    Collider2D ghostCollider;
    [SerializeField]
    Collider2D characterCollider;


    public Count count;
    public float maximumChanceOfApparition = 100f;
    public float minimumChanceOfApparition = 10f;
    public float currentChance = 0;

    public bool spawnGhost;
    public float spawn;
    public bool spawnRateReset;
    float resetTime;
    public bool stopRandomNumber;
    public bool canSpawnHere;
    bool isGameOverPossible = false;

   
    // Start is called before the first frame update
    void Start()
    {
        spawn = Random.Range(1, maximumChanceOfApparition);
        spawnGhost = true;
        spawnRateReset = false;
        resetTime = 0;
        canSpawnHere = gameObject.tag.Contains(("Loft"));
    }

    // Update is called once per frame
    void Update()
    {
        ApparitionRate();
        SpawnTimeReset();
    }

    public void ApparitionRate() // function for the apparition rate of the ghost
    {
        if (count.keepCount == 7 && stopRandomNumber == true)
        {
            stopRandomNumber = false;
            currentChance = minimumChanceOfApparition;
            spawn = Random.Range(1, maximumChanceOfApparition);
        }
        else if(count.keepCount > 7 && count.doAction == true)
        {
            count.doAction = false;
            currentChance += 5f;
            spawn = Random.Range(1, maximumChanceOfApparition);
        }
       

        if(spawn <= currentChance && spawnGhost == true)
        {
            
            EnemySpawn();
          
            disapear();
            disapearBgm();
            spawnGhost = false;
            isGameOverPossible = true;
        }

        if( isGameOverPossible ) {
            GameOver( );
        }

      //  newInstance = Instantiate(prefabMonster2, new Vector3(player.transform.position.x - distance2, player.transform.position.y, 0), Quaternion.identity);
       
    }

    public void EnemySpawn() // instanciate ghost + bgm
    {
        

       if(player.transform.position == GameObject.FindGameObjectWithTag("Loft").transform.position)
        {
            canSpawnHere = true;
        Debug.Log("ghost is here! run bitch!");
        newInstance = Instantiate(prefabMonster, new Vector3(player.transform.position.x - distance, player.transform.position.y, 0), Quaternion.identity);
        newBgm = Instantiate(ghostBGM, new Vector3(0, 0, 0), Quaternion.identity);
        currentChance = 0;
        SoundSystem.instance.PlayGhostBGM();
      
        }
       else
        {
            canSpawnHere = false;
            return;
        }
           

    }
    
    public void disapear() // destroy prefab ghost
    {
        float destroyTime = 10;
        resetTime = 0;
        spawnRateReset = true;

        spawn = Random.Range(1, maximumChanceOfApparition);
        

        Destroy(newInstance, destroyTime);
        
    }
    public void disapearBgm() // destroy the bgm
    {
        var destroyTimeBgm = 13;
        Destroy(newBgm, destroyTimeBgm);
    }

    public void SpawnTimeReset() // reset the spawn time 
    {
        if(spawnRateReset == true)
        {
            resetTime += Time.deltaTime;
            if( resetTime >= 10)
            {
                spawnGhost = true;
                count.keepCount = 0;
                currentChance = 0;

                spawnRateReset = false;
            }
        }
    }



    public void GameOver( ) // game over function
    {
        if( ghostCollider.IsTouching( characterCollider ) ) {
            SceneManager.LoadScene( "Game Over" );
            Debug.Log( "Funciona" );
        }
    }
}
