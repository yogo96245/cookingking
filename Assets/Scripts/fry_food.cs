using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fry_food : MonoBehaviour {

  public GameObject[] tofu; 
  private float[,] four_direction;
  private int[] tofu_direction;
  private float[] tofu_frytime;
  private bool is_sleep = false;
  private int complete_amount = 0;

  // Start is called before the first frame update
  void Start() {
    four_direction = new float[4, 2] { {0.1f, 0.1f}, {0.1f, -0.1f}, {-0.1f, -0.1f}, {-0.1f, 0.1f}};
    tofu_direction = new int[tofu.Length];
    tofu_frytime = new float[tofu.Length];
    for (int i = 0; i < tofu.Length; i++) {
      initialize(i);
    }
    
  }

  // Update is called once per frame
  void Update() {
    fry_time();
    if (!is_sleep) {
      StartCoroutine (tofu_move());
    }
    if (complete_amount == 6) {
      set_default();
      this.gameObject.SetActive (false);
      print ("complete");
    }
  }

  private void initialize(int i) {
    tofu_direction[i] = Random.Range (0, 4);
    tofu_frytime[i] = Random.Range (0.0f, 5.0f);
    tofu[i].GetComponent<Image>().sprite = Resources.Load <Sprite>("cut_before");
    // x: 550 y: 300
    tofu[i].transform.localPosition = new Vector2 (Random.Range (-300, 300), Random.Range (-200, 200));
  }

  IEnumerator tofu_move() {
    is_sleep = true;
    yield return new WaitForSeconds(1);
    for (int i = 0; i < tofu.Length; i++) {
      tofu[i].transform.position = new Vector2 (tofu[i].transform.position.x + four_direction[tofu_direction[i], 0], 
                                                tofu[i].transform.position.y + four_direction[tofu_direction[i], 1]);
    }
    is_sleep = false;
  }

  private void fry_time() {
    for (int i = 0; i < tofu.Length; i++) {
      tofu_frytime[i] += Time.deltaTime;
      if (tofu_frytime[i] >= 10.0f) {
        tofu[i].GetComponent<Image>().sprite = Resources.Load <Sprite>("fry_tofu");
      }
      if (tofu_frytime[i] >= 15.0f) {
        tofu[i].GetComponent<Image>().sprite = Resources.Load <Sprite>("burnt_tofu");
      }
      // print ("i = " + i + ", " + tofu_frytime[i]);
    }
    // print ("tofu0 = " + tofu_frytime[0]);
  }

  private void set_default() {
    is_sleep = false;
    complete_amount = 0;
    for (int i = 0; i < tofu.Length; i++) {
      initialize (i);
      tofu[i].SetActive (true);
    }
  }

  public void onclick_tofu (int tofu_number) {
    if (tofu[tofu_number].GetComponent<Image>().sprite.name == "fry_tofu") {
      tofu[tofu_number].SetActive (false);
      complete_amount++;
    }
    if (tofu[tofu_number].GetComponent<Image>().sprite.name == "burnt_tofu") {
      tofu[tofu_number].GetComponent<Image>().sprite = Resources.Load <Sprite>("cut_before");
      initialize (tofu_number);
    }
  }
}
