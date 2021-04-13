using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    private bool pulling;
    public bool flying;
    private bool isMouseDown;
    private Vector3 offset;
    private Animator animator;
    private SlingShotController slingShot;
    private const int IDLE = 0, PREPARED = 1, PULLING = 2, RELEASE = 3;

    private Vector3 lastPos;
    private Vector3 middle;
    private ParadolaRender paradola;

    private float maxLength;
    // Start is called before the first frame update
    void Start()
    {
        pulling = false;
        flying = false;
        slingShot = GameObject.Find("SlingShot").GetComponent<SlingShotController>();
        animator = GetComponent<Animator>();
        paradola = slingShot.paradola;
        middle = slingShot.getMiddle();
        maxLength = slingShot.maxLength;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            if (pulling)
            {
                float distance= slingShot.distance().magnitude;
                Debug.Log(distance);
                if (Mathf.Abs(distance) > 0.1)
                {
                    slingShot.setState(RELEASE);
                    animator.SetBool("release",true);
                    flying = true;
                    GetComponent<BirdMove>().enabled = false;
                }
                else
                {
                    slingShot.setState(PREPARED);
                }
                pulling = false;
            }
        }

        if (isMouseDown)
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            if (hit.collider != null)
            {
                if (hit.collider == this.GetComponent<CircleCollider2D>())
                {
                    pulling = true;
                    slingShot.setState(PULLING);
                    GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Static;
                   // MoveBird();
                }

            }
        }

        if (pulling)
        {
            MoveBird();
        }
    }
    void MoveBird()
    {
        offset = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset.z = 0;
        float length = (middle - offset).magnitude;
       // Debug.Log("length:"+length);
        if (length > maxLength)
        {
            Vector3 tmp = offset - middle;
            offset = middle+tmp * maxLength / length;
           // Debug.Log("sssss");
        }
        if (offset != lastPos)
        {
            transform.position = offset;
            lastPos = offset;
            paradola.displayParadola(slingShot.distance(),slingShot.strength,offset);
           // Debug.Log(lastPos+" "+offset);
        }

    }
}
