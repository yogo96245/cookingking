using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charControl : MonoBehaviour {
  public GameObject turn_forward;
  public GameObject turn_back;
  public GameObject turn_right;
  public float speed_scale;
  Animator my_animator;
  bool facing_right;

  // Start is called before the first frame update
  void Start() {
    my_animator = GetComponent<Animator>();
    facing_right = true;
  }

  // Update is called once per frame
  void Update() {
      float horizontal_move = Input.GetAxis("Horizontal");
      float vertical_move = Input.GetAxis("Vertical");
      my_animator.SetFloat("vertical_speed", vertical_move);
      my_animator.SetFloat("horizontal_speed", Mathf.Abs(horizontal_move));
      transform.position = new Vector2 (transform.position.x + horizontal_move * speed_scale * Time.deltaTime, 
                                        transform.position.y + vertical_move   * speed_scale * Time.deltaTime);
      // turn right
      if (horizontal_move > 0 && facing_right != true) {        
        Flip();
      }
      // turn left
      else if (horizontal_move < 0 && facing_right == true) {
        Flip();
      }
      if (Input.GetKeyDown (KeyCode.W)) {
        change_character_direction (turn_forward);
      }
      if (Input.GetKeyDown (KeyCode.S)) {
        change_character_direction (turn_back);
      }
      if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.A)) {
        change_character_direction (turn_right);
      }
      
  }

  void Flip() {
    Vector3 temp = transform.localScale;
    temp.x = temp.x * -1.0f;
    transform.localScale = temp;
    facing_right = !facing_right;
  }
  void change_character_direction (GameObject direction) {
    float x_error = 0.0f;
    float y_error = 0.0f;
    direction.transform.position = this.transform.position;
    if (this.gameObject.name != "chef_side" && direction == turn_right) {
      if (this.gameObject.name == "chef_back") {
        y_error = -1.3f;
      }
      else {
        y_error = -0.9f;
      }
    }
    if (this.gameObject.name == "chef_side" && direction != turn_right) {
      y_error = 1.3f;
      if (direction == turn_forward) {
        if (transform.localScale.x < 0) {
          x_error = -0.5f;
        }
        else {
          x_error = 0.5f;
        }
      }
    }
    direction.transform.position = new Vector2 (direction.transform.position.x + x_error, 
                                                direction.transform.position.y + y_error);
    this.gameObject.SetActive (false);
    direction.SetActive (true);
  }
}
