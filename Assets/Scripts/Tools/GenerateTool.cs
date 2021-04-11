using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTool : MonoBehaviour
{
    //public List<GameObject> tools;
    //public Transform toolPos;
    private SlingShotController slingShot;

    public GameObject tool;
    // Start is called before the first frame update
    void Start()
    {
        slingShot = GameObject.FindWithTag("slingshot").GetComponent<SlingShotController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeTool()
    {
        if (slingShot.getState() < 2)
        {
            tool =  Instantiate(tool, new Vector3(0,0,0), Quaternion.identity);
            //tool.transform.SetParent(toolPos);
            gameObject.SetActive(false);
        }
    }
}
