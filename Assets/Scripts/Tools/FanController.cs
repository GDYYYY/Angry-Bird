using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    public LayerMask birdMask;
    private float blowForce;
    public float force;
    private bool isBlowing;
    private Collider2D bird;
    //private GameObject checkPoint;
    public float checkRadius;
    public float checkHight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isBlowing = false;

        Vector2 posVector2 = transform.position;

        bird = Physics2D.OverlapBox(new Vector2(posVector2.x, posVector2.y + checkHight / 2), new Vector2(2 * checkRadius, checkHight), 0, birdMask);
        // Debug.Log(bird.gameObject.layer);
        isBlowing = bird;
        blow();
    }
    void blow()
    {
        if (isBlowing)
        {
            blowForce = 1 / (bird.transform.position.y - transform.position.y);
            Debug.Log(blowForce);
            bird.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, force * blowForce));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 posVector2 = transform.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new Vector2(posVector2.x, posVector2.y + checkHight / 2), new Vector3(2 * checkRadius, checkHight));
    }
}