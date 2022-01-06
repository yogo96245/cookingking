using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chef_collision : MonoBehaviour {
  public  GameObject cut_menu;
  public GameObject fry_menu;

  // Start is called before the first frame update
  void Start() {
         
  }

  // Update is called once per frame
  void Update() {
    
  }
  void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.tag == "cut_area" && Input.GetKeyDown (KeyCode.Space)) {
      cut_menu.SetActive(true);
    }
  }
  void OnTriggerStay2D(Collider2D collision) {
    Debug.Log (collision.name);
    if (collision.gameObject.tag == "cut_area" && Input.GetKeyDown (KeyCode.Space)) {
      cut_menu.SetActive(true);
    }
    if (collision.gameObject.tag == "fry_area" && Input.GetKeyDown (KeyCode.Space)) {
      GameObject.Find ("plate").SetActive (false);
      fry_menu.SetActive(true);
    }
    if (collision.name == "background" && Input.GetKeyDown (KeyCode.Space)) {
      if (gamedata.cut_tofu_done && gamedata.fry_tofu_done) {
        GameObject.Find ("done").SetActive (false);
        gamedata.cut_tofu_done = false;
        gamedata.fry_tofu_done = false;
        gamedata.sell_sum++;
        GameObject.Find ("amount").GetComponent<Text>().text = gamedata.sell_sum.ToString();
        print (gamedata.sell_sum);
      }
      else {
        print ("未完成!");
      }
    }
  }
}

