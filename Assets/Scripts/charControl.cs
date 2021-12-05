using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charControl : MonoBehaviour {

  Animator myAnimator;
  Rigidbody2D  myRigid; 
  bool facingRight;
  public float speedScale;
  //public GameObject a;

  // Start is called before the first frame update
  void Start()     {
    myAnimator = GetComponent<Animator>();
    myRigid = GetComponent<Rigidbody2D>();
    facingRight = true;
  }

  // Update is called once per frame
  void Update() {
      float horizontal_move = Input.GetAxis("Horizontal");
      float vertical_move = Input.GetAxis("Vertical");
      myAnimator.SetFloat("vertical_speed", vertical_move);
      myAnimator.SetFloat("horizontal_speed", Mathf.Abs(horizontal_move));
      myRigid.velocity = new Vector2 (horizontal_move * speedScale, myRigid.velocity.y);

      if (horizontal_move > 0 && facingRight != true) {
        //條件成立時的反應：圖片轉向
        Flip();
      }
      else if (horizontal_move < 0 && facingRight == true) {
        //圖片轉向
        Flip();
      }
      if (Input.GetKeyDown(KeyCode.Z)) {
        //myAnimator.GetComponent<Animator>().Animator = a  ;
      }
      
  }

  void Flip() {
    Vector3 temp = transform.localScale;
    temp.x = temp.x * -1.0f;
    transform.localScale = temp;
    facingRight = !facingRight;
  }
}
