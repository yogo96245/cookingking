using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamedata : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool cut_tofu_done;
    public static bool fry_tofu_done;
    public static int sell_sum;
    void Start()
    {
       cut_tofu_done = false;
       fry_tofu_done = false;
       sell_sum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
