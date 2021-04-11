using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakController : MonoBehaviour
{
    private Animator animator;
    public float maxForce;
    public int maxScore;

    private AudioSource sounds;

    private Rigidbody2D rb;
    private float curForce;
    private Vector3 v;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        curForce = maxForce;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        sounds = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        v = rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        playSound();
        float force;
        //Rigidbody2D other = collision.collider.GetComponent<Rigidbody2D>();
        if (collision.collider.tag == "land") //return;
        {
            force = rb.mass * v.magnitude * 10;
            //Debug.Log("mass:"+rb.mass+" v:"+v);
            //Debug.Log("fff:" + force + " cur:" + curForce);
        }
        else
        {
            Rigidbody2D other = collision.collider.GetComponent<Rigidbody2D>();
            force = (other.mass + rb.mass) * Mathf.Abs((other.velocity - rb.velocity).magnitude) * 10;
        }
        // Debug.Log("fff:" + force + " cur:" + curForce);
        curForce -= force;
        int state=1;
        
        if (curForce / maxForce > 0.5)
        {
            state = 0;
        }
        animator.SetInteger("state", state);
        if (curForce <= 0) Invoke("ItemDestory", 2.0f);
    }

    void ItemDestory()
    {
       // playSound();
        gameManager.addScore(maxScore);
        Destroy(this.gameObject);
    }

    void playSound()
    {
        sounds.Play();
    }
}
