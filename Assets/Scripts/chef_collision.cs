using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chef_collision : MonoBehaviour {
  public  GameObject cut_menu;

  // Start is called before the first frame update
  void Start() {
    Cursor.visible = false;     
  }

  // Update is called once per frame
  void Update() {
    
  }
  void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.tag == "cut_area" && Input.GetKeyDown (KeyCode.Space)) {
      Debug.Log ("enter");
      cut_menu.SetActive(true);
    }
  }
  void OnTriggerStay2D(Collider2D collision) {
    if (collision.gameObject.tag == "cut_area" && Input.GetKeyDown (KeyCode.Space)) {
      Debug.Log ("stay");
      cut_menu.SetActive(true);
      //Time.timeScale = 0f;
    }
  }
}

