using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] itemObject;

    public int flow;
    // Start is called before the first frame update
    void Start()
    {
        flow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for( int i = 0; i < itemObject.Length; i++)
        {
            if(i == flow && itemObject[i] != null)
            {
                itemObject[i].SetActive(true);
            }
            else if(i != flow && itemObject[i] != null)
            {
                itemObject[i].SetActive(false);
            }        
        }
    }
}
