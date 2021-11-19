using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 StartPos;
    private float RepeatWith;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        RepeatWith = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < StartPos.x -RepeatWith)
        {
            transform.position = StartPos;
        }
    }
}
