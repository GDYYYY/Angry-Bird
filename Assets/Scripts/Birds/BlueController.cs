using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueController : MonoBehaviour
{
    public GameObject boom;
    private Animator animator;
    private bool flying;
    private Rigidbody2D rb;
    private bool beAble;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        beAble = true;
    }

    // Update is called once per frame
    void Update()
    {
        flying = animator.GetBool("release");
        if (flying&&Input.GetKeyUp(KeyCode.Space)&&beAble)
        {
            Debug.Log("'aaaaaaa'");
            Instantiate(boom, transform.position, Quaternion.identity);
            rb.gravityScale=0;
            //rb.AddForce(new Vector2(0,rb.mass*10));
            Vector3 tmp = rb.velocity;
            tmp.y = tmp.y < 0 ? -tmp.y : tmp.y;
            rb.velocity = tmp;
            
            beAble = false;
        }
    }
    
    
}
