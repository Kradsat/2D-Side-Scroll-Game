using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitchTrigger : MonoBehaviour
{
    SceneSwitch sceneSwitch;

    [SerializeField]
    private string sceneName;

    private void Start()

    {
        sceneSwitch = FindObjectOfType<SceneSwitch>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sceneSwitch.switchScene(sceneName);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
