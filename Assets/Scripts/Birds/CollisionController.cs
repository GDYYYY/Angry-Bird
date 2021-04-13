using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private bool willStop;
    private SlingShotController slingShot;
    public GameManager manager;
    private bool alive;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        willStop = false;
        rb = GetComponent<Rigidbody2D>();
        slingShot = GameObject.Find("SlingShot").GetComponent<SlingShotController>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (willStop)
        {
            if (rb.velocity.magnitude == 0&&alive)
            {
                //slingShot.setState(0);
                alive = false;
                Invoke("check",t*0.99f);// manager.CheckEnd();
                Debug.Log("ssssssss");
                Destroy(gameObject,t);
                //GetComponent<CollisionController>().enabled = false;

            }

        }
    }

    void check()
    {
        manager.CheckEnd();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag=="wood") return;
        if (other.transform.tag == "edge") t = 0;
        else t = 0.3f;
        birdStop();
        willStop = true;
        slingShot.setState(0);
    }
    
    void birdStop()
    {
        //Debug.Log("hi");
        animator.SetBool("release", false);
    }
}
