using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fry_food : MonoBehaviour {

  public GameObject[] tofu; 
  private float[,] four_direction;
  private int[] tofu_direction;
  private bool is_sleep = false;

  // Start is called before the first frame update
  void Start() {
    four_direction = new float[4, 2] { {0.1f, 0.1f}, {0.1f, -0.1f}, {-0.1f, -0.1f}, {-0.1f, 0.1f}};
    tofu_direction = new int[tofu.Length];
    initialize_direction();
  }

  // Update is called once per frame
  void Update() {
    if (!is_sleep) {
      StartCoroutine (tofu_move());
    }
    
  }
  private void initialize_direction() {
    for (int i = 0; i < tofu.Length; i++) {
      tofu_direction[i] = Random.Range (0, 4);
      print (tofu_direction[i]);
    }
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
}
