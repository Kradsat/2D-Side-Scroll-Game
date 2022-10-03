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
    Collider2D ghostCollider;
    Collider2D characterCollider;


    public Count count;
    public float maximumChanceOfApparition = 100f;
    public float minimumChanceOfApparition = 10f;
    public float currentChance = 0;

    public bool spawnGhost;
    public float spawn;
    public bool spawnRateReset;
    float resetTime;
    bool isGameOverPossible = false;

    private void Awake()
    {
        if(newInstance != null)
        {
            Destroy(gameObject);
            return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spawn = Random.Range(1, maximumChanceOfApparition);
        spawnGhost = true;
        spawnRateReset = false;
        resetTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ApparitionRate();
        SpawnTimeReset();
    }

    public void ApparitionRate() // instantiate prefab + bgm
    {
        if (count.keepCount == 7)
        {
            currentChance = minimumChanceOfApparition;
        }
        else if(count.keepCount > 7 && count.doAction == true)
        {
            count.doAction = false;
            currentChance += 5f;
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

    public void EnemySpawn()
    {
        
       
        Debug.Log("ghost is here! run bitch!");
        newInstance = Instantiate(prefabMonster, new Vector3(player.transform.position.x - distance, player.transform.position.y, 0), Quaternion.identity);
        newBgm = Instantiate(ghostBGM, new Vector3(0, 0, 0), Quaternion.identity);
        currentChance = 0;
        SoundSystem.instance.PlayGhostBGM();

        ghostCollider = GameObject.FindGameObjectWithTag( "Enemy" ).GetComponent<Collider2D>( );
        characterCollider = GameObject.FindGameObjectWithTag( "Player" ).GetComponent<Collider2D>( );
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

    public void SpawnTimeReset()
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

    public void checkForEncounter()
    {
        

    }

    public void GameOver( ) {
        if( ghostCollider.IsTouching( characterCollider ) ) {
            SceneManager.LoadScene( "Game Over" );
            Debug.Log( "Funciona" );
        }
    }
}
