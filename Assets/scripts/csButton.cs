using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //SceneManager 사용위해
using UnityEngine.UI;


public class csButton : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void Button_start()
    {

        Invoke("startgame", .3f); // Invoke("실행함수", 지연시간)


    }
    public void Button_method()
    {
        Invoke("method", .3f);
    }
    public void Button_back()
    {
        Invoke("back", .3f);
       
    }
    public void Button_retry()
    {
        Invoke("retry", .3f);
    }
    public void startgame()
    {
        SceneManager.LoadScene("main_scene"); //다음으로 SampleScene 불러옴
    }

    public void method()
    {
        SceneManager.LoadScene("method_scene");
    }
    public void back()
    {
        SceneManager.LoadScene("start_scene");
    }
    public void retry()
    {
        SceneManager.LoadScene("main_scene");
    }
}