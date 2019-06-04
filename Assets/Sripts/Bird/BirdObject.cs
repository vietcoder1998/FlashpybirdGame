using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdObject : MonoBehaviour
{
    // Luc nay
    public float boundForce;
    public Vector3 rotation;
    public SpriteRenderer possition;

    private Rigidbody2D mybody;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;


    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;


    [SerializeField]
    private Text counterText;

    public static bool isAlive;
    public static bool isRunning;
    private int score;
    private bool didFlap;

    // Start is called before the first frame update
    void Awake()
    {
        isAlive = true;
        score = 0;
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _BirdMovement();
        _CheckAlive();
    }

    void _BirdMovement()
    {
        float angel = 0;

        if (isAlive)
        {
            if (didFlap == true)
            {
                didFlap = false;
                // velocity.x is  > 0 if object is going up, < 0 if object is going down 
                mybody.velocity = new Vector2(mybody.velocity.x, boundForce);
                audioSource.PlayOneShot(flyClip);
            }
        }
        if (mybody.velocity.y > 0)
        {
            // Tinh goc theo chieu z
            angel = Mathf.Lerp(0, 90, mybody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }

        else if (mybody.velocity.y < 0)
        {
            // Tinh goc theo chieu z
            angel = Mathf.Lerp(0, -90, -mybody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }

        else if (mybody.velocity.y == 0)
        {
            // Tinh goc theo chieu z
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void flapButton()
    {
        didFlap = true;
        Debug.Log(" IM FLAPPING ");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Thrown")
        {
            audioSource.PlayOneShot(pingClip);
            score += 1;
            counterText.text = "" + score;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Land" || collision.gameObject.tag == "PipeHolder")
        {
            audioSource.PlayOneShot(diedClip);
            anim.SetTrigger("Died");
            isAlive = false;
        }
    }

    private void _CheckAlive()
    {
        if (isAlive == false)
        {
            isRunning = false;
        }
    }
}
