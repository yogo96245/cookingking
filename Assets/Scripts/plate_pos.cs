using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate_pos : MonoBehaviour
{
    public GameObject[] character;
    public GameObject plate;
    private float deviation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in character)
        {
            if (obj.activeSelf)
            {
                if(obj.name == "chef_back" || obj.name == "chef_forward"){
                  deviation = 3;  
                } 
                else{
                  deviation = 3.5f;  
                }
            
                plate.transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y + deviation);
            }
        }
    }
}
