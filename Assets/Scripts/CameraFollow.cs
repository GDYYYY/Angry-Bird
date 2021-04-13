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
   // public Transform leftEdge;
    private float left;

    private float right;

    private float threshold;

    private bool follow;

    private bool followStone;
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
        
        if (!bird&&!followStone)
        {
            transform.position = origin;//birdPos.position+offset;
            updateLR();
            follow = false;
            return;
        }

        if (!followBird)
        {
            //if (followStone) Debug.Log("s");
            transform.position = origin;
            updateLR();
            follow = false;
            followStone = false;
            //followBird=bird;
        }
        if (!follow)
        {
           if(bird) followBird = bird;
           else return;
           
           //if(followStone) Debug.Log("ccc"+followBird);
           // Debug.Log(bird.transform.position);
        }

        if (followBird.transform.position.x > right - threshold)
        {
            follow = true;
            //if (followStone) Debug.Log("begin:"+followBird.name);
            //flyOffset = transform.position - bird.transform.position;
        }
        if (follow)
        {
            //Debug.Log("a");
            if(right<edge.position.x)//&&left>leftEdge.position.x)
            {
               // Debug.Log("move:"+followBird.name);
                Vector3 tmp = transform.position;
                tmp.x = followBird.transform.position.x + flyOffset;
                transform.position = tmp;
               // Debug.Log(transform.position);
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
        followStone = true;
       // Debug.Log("followBird:"+followBird.name);
    }
}
