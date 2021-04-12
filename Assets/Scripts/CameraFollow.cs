using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject bird;
    private Vector3 offset;
    public Transform birdPos;

    private float left;

    private float right;

    private float threshold;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - birdPos.position;
        //bird = Vector3.zero;
        updateLR();
        threshold = (right - left) / 3;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!bird)
        {
            transform.position = birdPos.position+offset;
            return;
        }
        Vector3 tmp = transform.position;
        tmp.x = bird.transform.position.x + offset.x;
        
        if (bird.transform.position.x > right-threshold || bird.transform.position.x < left)
        {
            transform.position = tmp;
            updateLR();
        }
    }

    void updateLR()
    {
        left = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        //Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).x;
        //最右边边界的x坐标
        right = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
    }
}
