using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndController : MonoBehaviour
{
    private DataSaver data;
    public Text userScore;
    public Text TitleText;

    public List<GameObject> ranks;
     // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindWithTag("data").GetComponent<DataSaver>();
        userScore.text = data.score.ToString("000");
        if (data.isWin)
        {
            TitleText.text = "You Win!";
            GameObject.Find("band").SetActive(true);
            if(data.curLevel<2) {GameObject.Find("next").SetActive(true);GameObject.Find("retry").SetActive(false);}
            else { GameObject.Find("next").SetActive(false); GameObject.Find("retry").SetActive(true); }
            Instantiate(ranks[data.rank-1],new Vector3(0,-1,0), Quaternion.identity);

        }
        else
        {
            TitleText.text = "You Lose";
            GameObject.Find("band").SetActive(false);
            GameObject.Find("next").SetActive(false);
            GameObject.Find("retry").SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
