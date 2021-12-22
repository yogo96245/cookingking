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

  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {
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
}
