using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cut_food : MonoBehaviour {
  public GameObject line1;
  public GameObject line2;
  public GameObject line3;
  public GameObject line4;
  public GameObject food;
  private bool is_sleep = false;
  private Vector2 mouse_position;
  // Start is called before the first frame update
  void Start() {
    
  }

  // Update is called once per frame
  void Update() {
    mouse_click();
    line_color_change();

    if (line1.activeSelf && line2.activeSelf && line3.activeSelf && line4.activeSelf) {
      food.GetComponent<Image>().sprite =  Resources.Load <Sprite>("cut_after");
      if (!is_sleep) {
        StartCoroutine (complete());
      }
    }
  }
  public void line1_show() {
    line1.SetActive(true);
  }
  public void line2_show() {
    line2.SetActive(true);
  }
  public void line3_show() {
    line3.SetActive(true);
  }
  public void line4_show() {
    line4.SetActive(true);
  }
  IEnumerator complete() {
    is_sleep = true;
    line1.SetActive(false);
    line2.SetActive(false);
    line3.SetActive(false);
    line4.SetActive(false);
    yield return new WaitForSeconds(3);
    this.gameObject.SetActive (false);
    is_sleep = false;
  }

  public void mouse_click(){
    if (Input.GetMouseButtonDown(0)){
      mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Debug.Log(mouse_position.x + " " + mouse_position.y);
    }
    else if (Input.GetMouseButtonUp(0)){
      mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Debug.Log(mouse_position.x + " " + mouse_position.y);
    }
    else{
      //
    }
  }

  public void line_color_change(){
    line1.GetComponent<Image>().color =  Color.Lerp( new Color32(255,13,13,100), new Color32(255,13,13,20), Mathf.PingPong(Time.time, 1));
    line2.GetComponent<Image>().color =  Color.Lerp( new Color32(255,13,13,100), new Color32(255,13,13,20), Mathf.PingPong(Time.time, 1));
    line3.GetComponent<Image>().color =  Color.Lerp( new Color32(255,13,13,100), new Color32(255,13,13,20), Mathf.PingPong(Time.time, 1));
    line4.GetComponent<Image>().color =  Color.Lerp( new Color32(255,13,13,100), new Color32(255,13,13,20), Mathf.PingPong(Time.time, 1));
  }

  public void begin_pos(){
    
  }
}