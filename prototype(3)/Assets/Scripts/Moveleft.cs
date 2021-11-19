using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Moveleft : MonoBehaviour
{
    private float moveSpeed = 30.0f;
    private PlayerController PlayerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControllerScript.Gameover == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if(transform.position.x < -15 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
