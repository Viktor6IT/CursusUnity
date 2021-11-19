using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    private Vector3 SpawnPosition = new Vector3(25,0,0);

    private float StartDelay = 2.0f;
    private float RepeatRate = 2.0f;

    private PlayerController PlayerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", StartDelay, RepeatRate);
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if (PlayerControllerScript.Gameover == false)
        {
            Instantiate(ObstaclePrefab, SpawnPosition, ObstaclePrefab.transform.rotation);
        }
    }
}
