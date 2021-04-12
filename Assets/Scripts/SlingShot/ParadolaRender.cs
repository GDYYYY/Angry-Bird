using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParadolaRender : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public int count;
    private Vector3 g;

    private Vector3 lastPos;
   // public GameObject fake;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = count;
        g = new Vector3(0,-9.8f,0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void displayParadola(Vector3 distance,int strength,Vector3 pos)
    {
        if (lastPos == pos) return;
        lastPos = pos;
        if(distance.magnitude<1) return;
        //Vector3 force = distance * strength;
        //Vector3 v = force * Time.deltaTime;
        //Debug.Log(force+" "+v);
        //GameObject x= Instantiate(fake, pos, Quaternion.identity);
        //x.GetComponent<Rigidbody2D>().AddForce(force);
        //Destroy(x,2f);
        Vector3 v = strength * distance;
        Vector3[] segments = new Vector3[count];

        for (int i = 0; i < count; i++)
        {
            float time2 = i * Time.fixedDeltaTime * 5;
            segments[i] = pos + v * time2 + 0.5f * g * Mathf.Pow(time2, 2);
        }
        //Debug.Log(segments);
        lineRenderer.SetPositions(segments.ToArray());
        lineRenderer.enabled = true;//放在最后防止画出上一只鸟的曲线
    }
}
