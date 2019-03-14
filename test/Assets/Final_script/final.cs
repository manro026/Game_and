using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class final : MonoBehaviour
{
    private Vector3 fp;   //Первая позиция касания
    private Vector3 lp;   //Последняя позиция касания
    private float dragDistance;  //Минимальная дистанция для определения свайпа
    private List<Vector3> touchPositions = new List<Vector3>(); //Храним все позиции касания в списке
    public float fall_speed=6f;
    public GameObject black;
    public GameObject blue;
    public GameObject red;
    public Animation clip;
    private time st;
    private SpawnList st_1;
    private GameObject Camera;
    public GameObject ends;

    void Start()
    {
        clip=GetComponent<Animation>();
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        st = Camera.GetComponent<time>();
        st_1 = Camera.GetComponent<SpawnList>();
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)  //используем цикл для отслеживания больше одного свайпа
        { 
            if (touch.phase == TouchPhase.Moved) //добавляем касания в список, как только они определены
            {
                touchPositions.Add(touch.position);            }

            if (touch.phase == TouchPhase.Ended) //проверяем, если палец убирается с экрана
            {
                fp = touchPositions[0]; //получаем первую позицию касания из списка касаний
                lp = touchPositions[touchPositions.Count - 1]; //позиция последнего касания
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   
                        if ((lp.x > fp.x))//Если движение было вправо
                        {                            
                                clip.Play("right");                            
                        }
                        else
                        {      
                                clip.Play("left");
                        }
                    }
                    else
                    {   
                        if (lp.y < fp.y)  
                        {
                            clip.Play("down");
                        }                       
                    }
                }
            }
            else
            {   //Это ответвление, как расстояние перемещения составляет менее 20% от высоты экрана

            }
        }
    }
    void left_f()
    {
        Destroy(gameObject);
        if (st_1.select_list==3)
            spawn();
        else
            end();
    }
    void right_f()
    {
        Destroy(gameObject);
        if (st_1.select_list == 2)
            spawn();
        else
            end();
    }
    void down()
    {
        Destroy(gameObject);
        if (st_1.select_list == 1)
            spawn();
        else
            end();
    }
    void spawn()//+
    {  
        st.timer += 1;
        st_1.select_list = Random.Range(1, 4);
        switch (st_1.select_list)
        {
            case 1:
                black.GetComponent<Down>().enabled = true;
                black.GetComponent<final>().enabled = true;
                black.GetComponent<Animation>().enabled = true;
                Instantiate(black, new Vector2(0, 60), Quaternion.identity);
                break;
            case 2:
                red.GetComponent<Down>().enabled = true;
                red.GetComponent<final>().enabled = true;
                red.GetComponent<Animation>().enabled = true;
                Instantiate(red, new Vector2(0, 60), Quaternion.identity);
                break;
            case 3:
                blue.GetComponent<Down>().enabled = true;
                blue.GetComponent<final>().enabled = true;
                blue.GetComponent<Animation>().enabled = true;
                Instantiate(blue, new Vector2(0, 60), Quaternion.identity);
                break;
        }

    }
    void end()
    {
        Instantiate(ends, new Vector2(0, 0), Quaternion.identity);
        st.enabled = false;
    }
}
