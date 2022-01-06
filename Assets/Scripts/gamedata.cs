using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamedata : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool cut_tofu_done = false;
    public static bool fry_tofu_done = false;
    public static int sell_sum = 0;
    void Start()
    {
       cut_tofu_done = false;
       fry_tofu_done = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
