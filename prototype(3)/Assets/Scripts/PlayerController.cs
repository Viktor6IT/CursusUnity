using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRB;
    private float jumpPower = 10.0f;
    private float gravityModifier = 1.5f;
    public bool IsOnGround = true;
    public bool Gameover;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            PlayerRB.AddForce(Vector3.up * jumpPower,ForceMode.Impulse);
            IsOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Gameover = true;
            Debug.Log("Game is over");
        }
    }
}
