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

    private float t;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        willStop = false;
        rb = GetComponent<Rigidbody2D>();
        slingShot = GameObject.Find("SlingShot").GetComponent<SlingShotController>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (willStop)
        {
            if (rb.velocity.magnitude == 0)
            {
                //slingShot.setState(0);
                //Invoke("check",t);// manager.CheckEnd();
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
        //if(other.transform.tag=="spring") return;
        if (other.transform.tag == "edge") t = 0;
        else t = 0.3f;
        birdStop();
        willStop = true;
        //slingShot.setState(0);
    }
    
    void birdStop()
    {
        //Debug.Log("hi");
        animator.SetBool("release", false);
    }
}
