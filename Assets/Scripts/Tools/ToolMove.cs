using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolMove : MonoBehaviour
{
    private bool isMouseDown;
    private Vector3 offset;
    private SlingShotController slingShot;
    
    // Start is called before the first frame update
    void Start()
    {
        slingShot = GameObject.FindWithTag("slingshot").GetComponent<SlingShotController>();
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
            
        }

        if (isMouseDown)
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            if (hit.collider != null)
            {
                if (hit.collider==this.GetComponentInParent<BoxCollider2D>()&&slingShot.getState()<2)
                {
                    MoveTool();
                }

            }
        }
    }

    void MoveTool()
    {
        offset = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset.z = 0;
        transform.position = offset;
    }
}
