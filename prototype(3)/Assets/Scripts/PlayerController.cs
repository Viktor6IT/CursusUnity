using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRB;
    private float jumpPower = 650.0f;
    private float gravityModifier = 1.8f;
    public bool IsOnGround = true;
    public bool Gameover;
    private Animator PlayerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        PlayerAnimation = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !Gameover)
        {
            PlayerRB.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            IsOnGround = false;
            PlayerAnimation.SetTrigger("Jump_trig");
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
            PlayerAnimation.SetBool("Death_b", true);
            PlayerAnimation.SetInteger("DeathType_int", 1);
        }
    }
}
