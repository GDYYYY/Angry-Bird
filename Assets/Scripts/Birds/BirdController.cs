using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private SlingShotController slingShot;
    private GameObject bird;
    private Rigidbody2D rb;
    private const int IDLE = 0, PREPARED = 1, PULLING = 2, RELEASE = 3,FLYING=4;

    //public GameObject newBird;
    // Start is called before the first frame update
    void Start()
    {
        slingShot = GameObject.Find("SlingShot").GetComponent<SlingShotController>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (slingShot.getState())
        {
            case PREPARED:
                bird.GetComponent<SpringJoint2D>().enabled = true;
                break;
            case PULLING:
                bird.GetComponent<SpringJoint2D>().enabled = false;
                bird.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                break;
            case RELEASE:
                //bird.GetComponent<SpringJoint2D>().enabled = true;
                bird.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                birdFly();
                break;
        }

    }

    void birdFly()
    {
        bird.GetComponent<SpringJoint2D>().enabled = false;
        //this.GetComponent<PolygonCollider2D>().enabled = false;
        bird.GetComponent<TrailRenderer>().enabled = true;
        rb = bird.GetComponent<Rigidbody2D>();
        Vector3 force = rb.mass * slingShot.distance() * 600;
        //force.y += rb.mass * 100;
        rb.AddForce(force);
        rb.freezeRotation = false;
        slingShot.setState(FLYING); //(IDLE);
        // slingShotState = IDLE; // FLYING;
    }
    public void InitializeBird(GameObject newBird)
    {
        if (slingShot.getState() == IDLE)
        {
            Destroy(bird);
        }
        bird = Instantiate(newBird, slingShot.birdPos.position, Quaternion.identity);
        bird.GetComponent<SpringJoint2D>().connectedBody =slingShot.rightSlingShot.GetComponent<Rigidbody2D>();
        //bird.GetComponent<SpringJoint2D>().enabled=false;
        bird.transform.SetParent(this.gameObject.transform);
    }
}
