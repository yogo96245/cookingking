using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cut_food : MonoBehaviour {
  public GameObject food;
  private bool is_sleep = false;
  private Vector2 mouse_position;
  private int flag=0,begin_position=0,end_position=0;
  public GameObject[] lines_group;

  // Start is called before the first frame update
  void Start() {
   
  }

  // Update is called once per frame

  /*-----------------------------------------------------------------------------------------------*/
  void Update() {


    mouse_click();
    line_color_change();

    if (lines_group[0].activeSelf && lines_group[1].activeSelf && lines_group[2].activeSelf && lines_group[3].activeSelf) {
      food.GetComponent<Image>().sprite =  Resources.Load <Sprite>("cut_after");
      if (!is_sleep) {
        StartCoroutine (complete());
      }
    }
  }

  /*-----------------------------------------------------------------------------------------------*/

  IEnumerator complete() {
    is_sleep = true;
    for(int i=0;i<lines_group.Length;i++){
      lines_group[i].SetActive(false);
    }
    yield return new WaitForSeconds(3);
    this.gameObject.SetActive (false);
    is_sleep = false;
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

      Debug.Log("pos is : " + mouse_position.x + "  " + mouse_position.y);
      Debug.Log("b is : " + begin_position);
    }

    if (Input.GetMouseButtonUp(0)){
      switch(flag){
        case 0 : end_position = cursor_ch(-17.3f,-3.3f);break;
        case 1 : end_position = cursor_ch(-13.3f,-3.3f);break;
        case 2 : end_position = cursor_ch(-9.3f,-3.3f);break;
        case 3 : end_position = cursor_ch(-6.67f,0.0f);break;
      }

      Debug.Log("pos is : " + mouse_position.x + "  " + mouse_position.y);
      Debug.Log("e is : " + end_position);
    }

    if(begin_position + end_position == 2) {
      lines_group[flag++].SetActive(false);
      lines_group[flag].SetActive(true);
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
    return ((Mathf.Abs(mouse_position.x - x)<0.3)&&(Mathf.Abs(mouse_position.y-y)<0.3))?1:0;
  }
}