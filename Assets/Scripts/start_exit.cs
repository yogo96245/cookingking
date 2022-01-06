using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class start_exit : MonoBehaviour {
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start() {
      SceneManager.LoadScene ("gaming");
    }
    public void exit() {
        Application.Quit();
    }
}
