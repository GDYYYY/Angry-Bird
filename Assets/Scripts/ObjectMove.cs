using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    private bool pulling;
    private bool isMouseDown;
    private Vector3 offset;
    private Animator animator;
    private SlingShotController slingShot;
    // Start is called before the first frame update
    void Start()
    {
        pulling = false;
        slingShot = GameObject.FindWithTag("slingshot").GetComponent<SlingShotController>();
        animator = GetComponent<Animator>();
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
                float distance= slingShot.distance();
                Debug.Log(distance);
                if (Mathf.Abs(distance) > 0.1)
                {
                    slingShot.setState(3);
                    animator.SetBool("release",true);
                }
                else
                {
                    slingShot.setState(1);
                }
                pulling = false;
            }
        }

        if (isMouseDown)
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "bird")
                {
                    pulling = true;
                    slingShot.setState(2);
                    MoveCube();
                }

            }
        }
    }
    void MoveCube()
    {
        offset = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset.z = 0;
        transform.position = offset;
    }
}
