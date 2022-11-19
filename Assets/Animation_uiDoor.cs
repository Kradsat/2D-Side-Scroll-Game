using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_uiDoor : MonoBehaviour
{
    public float amplitude;
    public float frequence;
    Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }
    private void Update()
    {
        transform.position = new Vector3(initialPos.x, Mathf.Sin(Time.time * frequence ) + amplitude + initialPos.y, 0);
    }
}
