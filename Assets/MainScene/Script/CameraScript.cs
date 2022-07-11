using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Camera camera;
    
    float sceneWidth = 16;

    int scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = this.transform.position.x;

        //change right scene
        if( xPos >= sceneWidth * scene )
        {
            scene++;
            camera.transform.position = new Vector2(xPos + ( sceneWidth / 2 ), 0);
        }

        //change left scene
        if( xPos < sceneWidth * ( scene - 1 ) && scene >= 2)
        {
            scene--;
            camera.transform.position = new Vector2(xPos - ( sceneWidth / 2 ), 0);
        }

    }
}
