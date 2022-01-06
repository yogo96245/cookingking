using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cut_food : MonoBehaviour {
  public GameObject food;
  public GameObject[] lines_group;
  public GameObject plate;
  private bool is_sleep = false;
  private bool cut_tofu_done;
  private Vector2 mouse_position;
  private int flag = 0, begin_position = 0, end_position = 0;


  // Start is called before the first frame update
  void Start() {
  }

  // Update is called once per frame

  /*-----------------------------------------------------------------------------------------------*/
  void Update() {
    mouse_click();
    line_color_change();

    if (!lines_group[0].activeSelf && !lines_group[1].activeSelf && !lines_group[2].activeSelf && !lines_group[3].activeSelf) {
      food.GetComponent<Image>().sprite =  Resources.Load <Sprite>("cut_after");
      if (!is_sleep) {
        StartCoroutine (complete());
      }
    }
  }

  /*-----------------------------------------------------------------------------------------------*/

  IEnumerator complete() {
    is_sleep = true;
    gamedata.cut_tofu_done = true;
    yield return new WaitForSeconds(3);
    set_default();
    this.gameObject.SetActive (false);
    plate.SetActive (true);
  }

  /*-----------------------------------------------------------------------------------------------*/

  public void mouse_click(){
    if (Input.GetMouseButtonDown(0)){
      switch(flag){
        case 0 : begin_position = cursor_ch(-17.3f,3.3f);break;
        case 1 : begin_position = cursor_ch(-13.3f,3.3f);break;
        case 2 : begin_position = cursor_ch(-9.3f,3.3f);break;
        case 3 : begin_position = cursor_ch(-19.9f,0.0f);break;
      }

//      Debug.Log("pos is : " + mouse_position.x + "  " + mouse_position.y);
//      Debug.Log("b is : " + begin_position);
    }

    if (Input.GetMouseButtonUp(0)){
      switch(flag){
        case 0 : end_position = cursor_ch(-17.3f,-3.3f);break;
        case 1 : end_position = cursor_ch(-13.3f,-3.3f);break;
        case 2 : end_position = cursor_ch(-9.3f,-3.3f);break;
        case 3 : end_position = cursor_ch(-6.67f,0.0f);break;
      }

//      Debug.Log("pos is : " + mouse_position.x + "  " + mouse_position.y);
//      Debug.Log("e is : " + end_position);

      if(begin_position + end_position == 2) {
        lines_group[flag++].SetActive(false);
        if (flag < 4) {
          lines_group[flag].SetActive(true);
        }
      }
      begin_position=0;
      end_position=0;
    }
  }

  /*-----------------------------------------------------------------------------------------------*/

  public void line_color_change(){
    for(int i=0;i<lines_group.Length;i++)
      lines_group[i].GetComponent<Image>().color =  Color.Lerp( new Color32(255,13,13,100), new Color32(255,13,13,20), Mathf.PingPong(Time.time, 1));
  }

  /*-----------------------------------------------------------------------------------------------*/

  private int cursor_ch(float x , float y){
    mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    return ((Mathf.Abs(mouse_position.x - x)<0.4f)&&(Mathf.Abs(mouse_position.y-y)<0.4f))?1:0;
  }

  /*-----------------------------------------------------------------------------------------------*/
  private void set_default() {
    is_sleep = false;
    Cursor.visible = true;
    GameObject.Find ("knife").transform.position = new Vector2(0, 0);
    food.GetComponent<Image>().sprite = Resources.Load <Sprite>("cut_before");
    for (int i = 1; i <=3; i++) {
      lines_group[i].SetActive (false);  
    }
    lines_group[0].SetActive (true);
    flag = 0;
  }
  /*-----------------------------------------------------------------------------------------------*/
  public void close() {
    set_default();
    this.gameObject.SetActive (false);
  }
}

