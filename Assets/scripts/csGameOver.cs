using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csGameOver : main_car_Controller
{

    public Text endtimetext;



    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        // endtimetext.text = Main_Capsule_Controller.endTime.ToString("F");
        endtimetext.text = endTime.ToString("F");
    }

    // Update is called once per frame
    void Update()
    {

    }
}