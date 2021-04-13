using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject bird;
    private GameObject followBird;
    //private Vector3 offset;
    private Vector3 origin;
    private float flyOffset;
   // public Transform birdPos;
    public Transform edge;
    private float left;

    private float right;

    private float threshold;

    private bool follow;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
       // offset = transform.position - birdPos.position;
        follow = false;
        //bird = Vector3.zero;
        updateLR();
        threshold = (right - left) / 3;
        flyOffset = transform.position.x - right + threshold;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (!bird)
        {
            transform.position = origin;//birdPos.position+offset;
            updateLR();
            follow = false;
            return;
        }

        if (!followBird)
        {
            transform.position = origin;
            updateLR();
            follow = false;
        }
        if (!follow)
        {
            followBird = bird;
            Debug.Log(bird.transform.position);
        }
        //Vector3 tmp = transform.position;
        //tmp.x = bird.transform.position.x + offset.x;

        if (followBird.transform.position.x > right - threshold)
        {
            follow = true;
            //flyOffset = transform.position - bird.transform.position;
        }
        if (follow)
        {
            if(right<edge.position.x)//&&left>leftEdge.position)
            {
                Vector3 tmp = transform.position;
                tmp.x = followBird.transform.position.x + flyOffset;
                transform.position = tmp;
                Debug.Log(transform.position);
                updateLR();
            }
        }
    }

    void updateLR()
    {
        left = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        //Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).x;
        //最右边边界的x坐标
        right = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
    }

    public void changeFollow(GameObject boom)
    {
        followBird = boom;
    }
}
