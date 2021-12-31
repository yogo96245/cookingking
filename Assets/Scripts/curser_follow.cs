using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curser_follow : MonoBehaviour {
  public GameObject follow_image;
  private Vector2 mouse_position;

  // Start is called before the first frame update
  void Start() {
  }

  // Update is called once per frame
  void Update() {
    if (GameObject.Find ("cut_menu").activeSelf) {
      Cursor.visible = false;
    }
    mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    if (Mathf.Abs(mouse_position.x) < Screen.width || Mathf.Abs(mouse_position.y) < Screen.height) {
      follow_image.transform.position = new Vector2(mouse_position.x, mouse_position.y);
    }
    else{
      print ("mouse out");
    }
  }
}
