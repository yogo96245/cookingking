using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charControl : MonoBehaviour {

  Animator myAnimator;
  Rigidbody2D  myRigid; 
  bool facingRight;
  public float speedScale;

  // Start is called before the first frame update
  void Start()     {
    myAnimator = GetComponent<Animator>();
    myRigid = GetComponent<Rigidbody2D>();
    facingRight = true;
  }

  // Update is called once per frame
  void Update() {
      float move = Input.GetAxis("Horizontal");
//      Debug.Log("按鍵數值= " + move);
      myAnimator.SetFloat("Speed", Mathf.Abs(move));
      myRigid.velocity = new Vector2 (move * speedScale, myRigid.velocity.y);
      if (move > 0 && facingRight != true) {
        //條件成立時的反應：圖片轉向
        Flip();
      }
      else if (move < 0 && facingRight == true) {
        //圖片轉向
        Flip();
      }
  }

  void Flip() {
    Vector3 temp = transform.localScale;
    temp.x = temp.x * -1.0f;
    transform.localScale = temp;
    facingRight = !facingRight;
  }
}
