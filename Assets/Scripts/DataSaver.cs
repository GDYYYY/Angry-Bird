using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    private static DataSaver instance;
    public int score;
    public bool isWin;
    public int curLevel;

    public int rank;
    // Start is called before the first frame update
    void Start()
    {
       // GameObject.DontDestroyOnLoad(gameObject);
        //curLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }
}
