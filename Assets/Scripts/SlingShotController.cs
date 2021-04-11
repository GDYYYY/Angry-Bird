using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlingShotController : MonoBehaviour
{
    public LineRenderer rightLineRender, leftLineRender;
    public Transform rightSlingShot, leftSlingShot;
    public Transform birdPos;
    public List<GameObject> birds;
    private GameObject lastButton;
    private GameObject bird;
    private Rigidbody2D rb;
    private Vector3 middlePoint;
    private const int IDLE = 0, PREPARED=1,PULLING = 2, RELEASE = 3,FLYING=4;
    private int slingShotState=IDLE;//0 for idle,1 for loading,2 for pulling,3 for release
    private AudioSource sounds;
    
    // Start is called before the first frame update
    void Start()
    {
        rightLineRender.enabled = false;
        leftLineRender.enabled = false;
        //correct position & state
        rightLineRender.SetPosition(0,rightSlingShot.position);
        leftLineRender.SetPosition(0,leftSlingShot.position);
        middlePoint = new Vector3((leftSlingShot.position.x + rightSlingShot.position.x) / 2,
            (leftSlingShot.position.y + rightSlingShot.position.y) / 2,0);
        slingShotState = IDLE;

        sounds = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (slingShotState)
        {
            case PREPARED:
                displayLineRenders();
                bird.GetComponent<SpringJoint2D>().enabled = true;
                break;
            case PULLING:
                displayLineRenders();
                bird.GetComponent<SpringJoint2D>().enabled = false;
                bird.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                // displayParabola();
                break;
            case RELEASE:
                //bird.GetComponent<SpringJoint2D>().enabled = true;
                bird.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                leftLineRender.enabled = false;
                rightLineRender.enabled = false;
                birdFly();
                break;
        }
       // Debug.Log(slingShotState);
        
    }

    void birdFly()
    {
        bird.GetComponent<SpringJoint2D>().enabled = false;
        //this.GetComponent<PolygonCollider2D>().enabled = false;
        bird.GetComponent<TrailRenderer>().enabled = true;
        rb = bird.GetComponent<Rigidbody2D>();
        Vector3 force = (middlePoint - bird.transform.position)*600;
        //force.y += rb.mass * 100;
        rb.AddForce(force);
        rb.freezeRotation = false;
        slingShotState = FLYING;
    }
    public void InitializeBird(int index)
    {
        if (slingShotState == IDLE)
        {
            Destroy(bird);
            Debug.Log("aaa");
            bird = Instantiate(birds[index], birdPos.position, Quaternion.identity);
            bird.GetComponent<SpringJoint2D>().connectedBody = rightSlingShot.GetComponent<Rigidbody2D>();
            //bird.GetComponent<SpringJoint2D>().enabled=false;
            bird.transform.SetParent(this.gameObject.transform);
        }
        else if(slingShotState==PREPARED)
        {
            Destroy(bird);
            //bird = null;
            bird = Instantiate(birds[index], birdPos.position, Quaternion.identity);
            bird.GetComponent<SpringJoint2D>().connectedBody = rightSlingShot.GetComponent<Rigidbody2D>();
            //bird.GetComponent<SpringJoint2D>().enabled = false;
            bird.transform.SetParent(this.gameObject.transform);
        }
    }

    public void controlButton(GameObject cur)
    {
       
       if (slingShotState == IDLE)
       {
           Debug.Log("111");
           cur.SetActive(false);
           lastButton =cur;
           slingShotState = PREPARED;
       }
       else if (slingShotState == PREPARED)
       {
           cur.SetActive(false);
           lastButton.SetActive(true);
           lastButton = cur;
       }
    }    

    void displayLineRenders()
    {
        leftLineRender.SetPosition(1,bird.transform.position);
        rightLineRender.SetPosition(1,bird.transform.position);
        leftLineRender.enabled = true;
        rightLineRender.enabled = true;
    }

    public void setState(int s)
    {
        slingShotState = s;
        if (s == RELEASE)
            playSound();
        //Debug.Log(s+":state");
    }
    public int getState()
    {
        return slingShotState;
    }

    public float distance()
    {
        return (middlePoint - bird.transform.position).magnitude;
    }

    void playSound()
    {
        sounds.Play();
    }
}
