using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRB;
    private float jumpPower = 651.2f;
    private float gravityModifier = 1.9f;
    public bool IsOnGround = true;

    public bool Gameover;

    private Animator PlayerAnimation;
    public ParticleSystem ExplosionParticle;
    public ParticleSystem DirtParticle;
    public AudioClip JumpSound;
    public AudioClip CrashSound;
    private AudioSource playerAudio;
    private float JumpVolume = 0.75f;
    private float CrashVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        PlayerAnimation = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !Gameover)
        {
            PlayerRB.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            IsOnGround = false;
            PlayerAnimation.SetTrigger("Jump_trig");
            DirtParticle.Stop();
            playerAudio.PlayOneShot(JumpSound,JumpVolume);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            DirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Gameover = true;
            Debug.Log("Game is over");
            PlayerAnimation.SetBool("Death_b", true);
            PlayerAnimation.SetInteger("DeathType_int", 1);
            ExplosionParticle.Play();
            DirtParticle.Stop();
            playerAudio.PlayOneShot(CrashSound, CrashVolume);

        }
    }
}
