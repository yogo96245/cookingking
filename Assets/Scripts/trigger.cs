using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
      
    }
    void  OnTriggerEnter2D (Collider2D other) {
        
        if (other.name == "spheria") {
          //Destroy (this.gameObject);
          this.gameObject.SetActive (false);
        }
    }
    void  OnTriggerStay2D (Collider2D other) {
        Debug.Log ("stay"); 
    }
    void  OnTriggerExit2D (Collider2D other) {
      if (other.name == "spheria") {
        Debug.Log (this.gameObject.activeSelf);;
      }

    }
}
