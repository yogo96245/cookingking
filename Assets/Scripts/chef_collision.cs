using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chef_collision : MonoBehaviour {
  public  GameObject cut_menu;
  // Start is called before the first frame update
   void Start() {
       
  }

  // Update is called once per frame
  void Update() {
    
  }
  void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.tag == "cut_area" && Input.GetKeyDown (KeyCode.Space)) {
      Debug.Log ("enter");
      cut_menu.SetActive(true);
    }
  }
  void OnCollisionStay2D(Collision2D collision) {
    if (collision.gameObject.tag == "cut_area" && Input.GetKeyDown (KeyCode.Space)) {
      Debug.Log ("stay");
      cut_menu.SetActive(true);
      //Time.timeScale = 0f;
    }
  }
}

