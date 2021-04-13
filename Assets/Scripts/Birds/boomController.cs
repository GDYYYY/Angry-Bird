using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomController : MonoBehaviour
{
    private float t;
    private bool willStop;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (willStop)
        {
            if (rb.velocity.magnitude == 0)
            {
                Destroy(gameObject, t);
            }

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "edge") t = 0;
        else t = 1f;
        willStop = true;
    }
}
