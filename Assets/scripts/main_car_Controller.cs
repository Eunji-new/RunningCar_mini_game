
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI사용위해서
using UnityEngine.SceneManagement; //SceneManager 사용위해


public class main_car_Controller : MonoBehaviour
{
    public float moveSpeed = 6.0f;
    public float gap = 2.4f; //왼,중,오 간격
    private Transform character = null;
    public int life = 5; //생명 5개
    public Transform Tree; // 배럴 프리팹
 

    public Transform Center;
    public Transform Middle;
    public Transform Middle2;
    public Transform Middle3;
    public Transform Middle4;
    public Transform Middle5;

    public Transform Left;
    public Transform Left2;
    public Transform Left3;
    public Transform Left4;
    public Transform Left5;

    public Transform Right;
    public Transform Right2;
    public Transform Right3;
    public Transform Right4;
    public Transform Right5;

    public int n = 0;
    public int eight_z = 0; // 캐릭터가 8만큼씩 갔을때. 
    public Text timeText; //시간텍스트
    public Text lifeText;  // 생명텍스트
    float time = 0f;        //시간
    public static float endTime; // 버틴 시간



    /* 씬이 바뀌어도 이 게임오브젝트는 사라지지않게 함.
     void Awake()
      {
          DontDestroyOnLoad(gameObject);
      }
      */
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080,true);
        character = this.gameObject.GetComponent<Transform>(); //메인 캡슐 캐릭터
        lifeText.text = "Life : ♥ ♥ ♥ ♥ ♥"; //처음 생명 5개
        start_tree();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Create_tree();
        if ((int)character.position.z % 6 >= 1 && (int)character.position.z % 6 <= 5) //6~7 사이에 없을때
            eight_z = 0; // 8마다 한번씩 값 초기화 -> 8마다 배럴생성 가능하도록 만들어줌
        if (time >= 0)
        {
            time += Time.deltaTime; // 프레임 수 더해준다..((delta.Time으로 어느 컴이든 같게 기준
            timeText.text = "Time : " + time.ToString("F"); //time.Tostring("F")는 소숫점 많이 방출 방지
        }

    } //Update

    void start_tree()
    {
        int empty = (int)Random.Range(1, 4); //가는길에 Tree비워둘 곳.
        int empty2 = (int)Random.Range(1, 4);
        int empty3 = (int)Random.Range(1, 4);
        int empty4 = (int)Random.Range(1, 4);
  


        if (empty2 == 1) //왼쪽 비워놓기
        {
            Instantiate(Tree, Middle2.position, Quaternion.identity);
            Instantiate(Tree, Right2.position, Quaternion.identity);
        }
        else if (empty2 == 2)// 가운데 비워놓기
        {
            Instantiate(Tree, Left2.position, Quaternion.identity);
            Instantiate(Tree, Right2.position, Quaternion.identity);
        }
        else //오른쪽 비워놓기
        {
            Instantiate(Tree, Middle2.position, Quaternion.identity);
            Instantiate(Tree, Left2.position, Quaternion.identity);
        }

 
        if (empty3 == 1) //왼쪽 비워놓기
        {
            Instantiate(Tree, Middle3.position, Quaternion.identity);
            Instantiate(Tree, Right3.position, Quaternion.identity);
        }
        else if (empty3 == 2)// 가운데 비워놓기
        {
            Instantiate(Tree, Left3.position, Quaternion.identity);
            Instantiate(Tree, Right3.position, Quaternion.identity);
        }
        else //오른쪽 비워놓기
        {
            Instantiate(Tree, Middle3.position, Quaternion.identity);
            Instantiate(Tree, Left3.position, Quaternion.identity);
        }


        if (empty4 == 1) //왼쪽 비워놓기
        {
            Instantiate(Tree, Middle4.position, Quaternion.identity);
            Instantiate(Tree, Right4.position, Quaternion.identity);
        }
        else if (empty4 == 2)// 가운데 비워놓기
        {
            Instantiate(Tree, Left4.position, Quaternion.identity);
            Instantiate(Tree, Right4.position, Quaternion.identity);
        }
        else //오른쪽 비워놓기
        {
            Instantiate(Tree, Middle4.position, Quaternion.identity);
            Instantiate(Tree, Left4.position, Quaternion.identity);
        }


    }

    void move() //캐릭터 기본 이동
    {

 
        character.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //무조건 앞으로 이동함
        Center.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //무조건 가운데에 고정(left, middle, right 고정해줌)

        if (Input.GetKeyDown(KeyCode.LeftArrow)) //왼쪽 방향키는 왼쪽
        {
            if (character.position.x < 1 && character.position.x > -1) //현재 중앙이면
            {
                character.Translate(-gap, 0, moveSpeed * Time.deltaTime); //왼쪽으로

            }
            else if (character.position.x == gap) //현재 오른쪽이면
            {
                character.Translate(-gap, 0, moveSpeed * Time.deltaTime); //중앙으로
            }

        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) // 오른쪽 방향키는 오른쪽
        {
            if (character.position.x < 1 && character.position.x > -1) //현재 중앙이면
            {
                character.Translate(gap, 0, moveSpeed * Time.deltaTime); //오른쪽으로

            }
            else if (character.position.x == -gap) //현재 왼쪽이면
            {

                character.Translate(gap, 0, moveSpeed * Time.deltaTime); //중앙으로

            }
        }
        if (n % 30 == 0)
        {
            moveSpeed += 0.01f; //속도 높
        }

    }

    void Create_tree() //배럴 랜덤생성
    {

        //캐릭터가 ~만큼 전진했을때 생성되는걸로 맞추면 좋을것같당.
        if (((int)character.position.z) % 6 == 0 && eight_z == 0) //8~9이
        {
            eight_z++;
            int empty5 = (int)Random.Range(1, 4); //가는길에 Tree 비워둘 곳.

            if (empty5 == 1) //왼쪽 비워놓기
            {
                Instantiate(Tree, Middle5.position, Quaternion.identity);
                Instantiate(Tree, Right5.position, Quaternion.identity);
            }
            else if (empty5 == 2)// 가운데 비워놓기
            {
                Instantiate(Tree, Left5.position, Quaternion.identity);
                Instantiate(Tree, Right5.position, Quaternion.identity);
            }
            else //오른쪽 비워놓기
            {
                Instantiate(Tree, Middle5.position, Quaternion.identity);
                Instantiate(Tree, Left5.position, Quaternion.identity);
            }

        }



    }
    public void OnTriggerEnter(Collider coll)
    {

        if (coll.tag == "Tree") //Tree과 부딪히면
        {
            Debug.Log("충돌 감지");
            life--; //생명 하나 줄어듦
            Destroy(coll.gameObject); //충돌한 배럴 제거
            if (life == 4)
                lifeText.text = "Life : ♥ ♥ ♥ ♥";
            else if (life == 3)
                lifeText.text = "Life : ♥ ♥ ♥";
            else if (life == 2)
                lifeText.text = "Life : ♥ ♥";
            else if (life == 1)
                lifeText.text = "Life : ♥";
            else
            {
                lifeText.text = "Life : ";
                endTime = time;
                Button();
            }
        }

    }
    private void Button()
    {
        Invoke("gameover", .1f); // Invoke("실행함수", 지연시간)
    }
    public void gameover()
    {

        SceneManager.LoadScene("GameOver"); //다음으로 씬 GameOver 불러옴

        Debug.Log("게임오버 시간 :" + endTime);


    }

}
