using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class end_form : MonoBehaviour {
    public GameObject sell_amount;
    public GameObject earn_amount;
    // Start is called before the first frame update
    void Start() {
      sell_amount.GetComponent<Text>().text = gamedata.sell_sum.ToString();
      earn_amount.GetComponent<Text>().text = (gamedata.sell_sum * 50).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
