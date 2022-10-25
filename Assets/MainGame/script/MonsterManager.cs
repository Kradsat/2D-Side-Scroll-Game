using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterManager : MonoBehaviour
{
    public GameObject prefabMonster;
    public GameObject prefabMonster2;
    public GameObject player;
    public GameObject newInstance;
    public GameObject ghostBGM;
    private GameObject newBgm;
    public float distance = 85f;
    public float distance2 = -85f;
    public Vector3 startingPosition;

    [SerializeField]
    Collider2D ghostCollider;
    [SerializeField]
    Collider2D characterCollider;

    [SerializeField]
    Monster monsterScript;
    [SerializeField]
    GameObject[] doorGameObject;

    public Count count;
    public float maximumChanceOfApparition = 100f;
    public float minimumChanceOfApparition = 10f;
    public float currentChance = 0;

    public bool spawnGhost;
    public float spawn;
    public bool spawnRateReset;
    float resetTime;
    public bool stopRandomNumber;
    public OpenTheDoor open;
    public bool isGameOverPossible = false;
    public bool canDisepear = false;


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

    public void ApparitionRate() // function for the apparition rate of the ghost
    {
        if (count.keepCount == 7 && stopRandomNumber == true) //  give a random spawn  rate with a minimum chance of 10
        {
            stopRandomNumber = false;
            currentChance = minimumChanceOfApparition;
            spawn = Random.Range(1, maximumChanceOfApparition);
        }
        else if (count.keepCount > 7 && count.doAction == true && stopRandomNumber == false) // give a new spawn rate at each action and add 5 of the current chance
        {
            count.doAction = false;
            currentChance += 5f;
            spawn = Random.Range(1, maximumChanceOfApparition);
        }


        if (spawn <= currentChance && spawnGhost == true)// spawn the ghost 
        {
            if (count.canSpawnhere == true) // check inside or oustide of the room
            {
                Debug.Log("Outside Room");
                EnemySpawn();

                spawnGhost = false;
                isGameOverPossible = true;
            } else // oustide of room = stop the random number of the spawn
            {
                Debug.Log("inside Room");
                stopRandomNumber = true;
            }
        }
        
        if (canDisepear == true)
        {
            disapear();
        }

        if (isGameOverPossible && ghostCollider != null)// check if game over is possible
        {
            GameOver( );
        }    
        //  newInstance = Instantiate(prefabMonster2, new Vector3(player.transform.position.x - distance2, player.transform.position.y, 0), Quaternion.identity);
    }

    public void EnemySpawn() // instanciate ghost + bgm
    {
        Debug.Log("ghost is here! run bitch!");

        newInstance = Instantiate(prefabMonster, new Vector3(player.transform.position.x - distance, player.transform.position.y, 0), Quaternion.identity);
        monsterScript = newInstance.GetComponentInChildren<Monster>();
        for( int i = 0; i < doorGameObject.Length; i++)
        {
            monsterScript.doorObject[i] = doorGameObject[i];
        }
        monsterScript.GetDoorPosition(doorGameObject.Length);

        newBgm = Instantiate(ghostBGM, new Vector3(0, 0, 0), Quaternion.identity);
        SoundSystem.instance.PlayGhostBGM();

        currentChance = 0;

        ghostCollider = GameObject.FindGameObjectWithTag( "Enemy" ).GetComponent<Collider2D>( );
        characterCollider = GameObject.FindGameObjectWithTag( "Player" ).GetComponent<Collider2D>( );
        canDisepear = true;
    }

    public void disapear() // destroy prefab ghost after 10 sec
    {
        if(count.keepCountOnlyMovement >= 5 )
        {
            resetTime = 0;
            spawnRateReset = true;
            count.keepCountOnlyMovement = 0;

            spawn = Random.Range(1, maximumChanceOfApparition);
            Destroy(newInstance);//destroyTime);
            isGameOverPossible = false;
            canDisepear = false;
            disapearBgm();
        }
        //float destroyTime = 10;\
        //
    }
    
    public void disapearBgm() // destroy the bgm after 13 sec
    {
        var destroyTimeBgm = 3;
        Destroy(newBgm, destroyTimeBgm);
    }

    public void SpawnTimeReset() // reset the spawn time 
    {
        if (spawnRateReset == true)
        {
            resetTime += Time.deltaTime;
            if (resetTime >= 10)
            {
                spawnGhost = true;
                count.keepCount = 0;
                count.keepCountOnlyMovement = 0;
                currentChance = 0;
                stopRandomNumber = false;

                spawnRateReset = false;
            }
        }
    }



    public void GameOver() // game over function
    {
        if (ghostCollider.IsTouching(characterCollider))
        {
            SceneManager.LoadScene("Game Over");
            Debug.Log("Funciona");
        }
    }
}
