using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Game : MonoBehaviour, IDragHandler, IBeginDragHandler {
    public GameObject list_red;

    public GameObject list_black;

    public GameObject list_blue;

    public GameObject end_menu;

    private GameObject list;

    private Animation clip;

    private int select_list;

    private bool isView;

    public float timer = 10f;

    private bool timer_flag = true;

    public Slider slider_time;

    private int score;

    public Text score_text;

    private bool preview_flag;

    private float preview;

    public Image preview_image;

    private float test;
    internal void Start() {
        preview_flag = true;
        select_list = Random.Range(1, 4);
        Spawn_list();
    }

    internal void Update() {
        int score_save;
        score_save = PlayerPrefs.GetInt("score_save");
        if (score_save < score)
            PlayerPrefs.SetInt("score_save", score);       
            {
                if (!timer_flag && timer > 0)
                {//таймер
                    timer -= Time.deltaTime * test;
                    slider_time.value = timer;
                    isView = true;
                }
                else if (0 > timer && isView == true)//флаг доб
                {
                    game_over();
                    isView = false;
                }
            }        
    }

    public void OnBeginDrag(PointerEventData eventData) {

        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))

        {

            if (eventData.delta.x > 0)
            {
                if (preview == 2|| preview == 1)
                {
                    StartCoroutine(svaip_list_right());
                    good_svaip();
                }
                else
                    game_over();
            }
            else
            {
                if (preview == 3)
                {
                    StartCoroutine(svaip_list_left());
                    good_svaip();
                }
                else
                    game_over();
            }

        }

       /* else

        {

            if (eventData.delta.y < 0)
            {
                if (preview == 1)
                {
                    StartCoroutine(svaip_list_down());
                    good_svaip();
                }
                else
                    game_over();
            }

        }*/
    }

    public void OnDrag(PointerEventData eventData) {
    }

    private void Spawn_list() {
        timer_flag = false;
        preview = select_list;
        switch (select_list)
        {
            case 1:
                //list = Instantiate(list_black);
                //StartCoroutine(down_list());
               // break;
            case 2:
                list = Instantiate(list_red);
                StartCoroutine(down_list());
                break;
            case 3:
                list = Instantiate(list_blue);
                StartCoroutine(down_list());
                break;
        }
        if (!preview_flag)
            select_list = Random.Range(1, 4);
        preview_flag = false;
        show_preview();
    }

    internal IEnumerator down_list() {
        clip = list.GetComponent<Animation>();
        clip.Play("start_down");
        yield return new WaitForSeconds(clip.GetClip("start_down").length);
    }

    internal IEnumerator svaip_list_left() {
        clip = list.GetComponent<Animation>();
        clip.Play("left");
        yield return new WaitForSeconds(clip.GetClip("left").length);
        Destroy(list);
        Spawn_list();
    }

    internal IEnumerator svaip_list_right() {
        clip = list.GetComponent<Animation>();
        clip.Play("right");
        yield return new WaitForSeconds(clip.GetClip("right").length);
        Destroy(list);
        Spawn_list();
    }

    internal IEnumerator svaip_list_down() {
        clip = list.GetComponent<Animation>();
        clip.Play("down");
        yield return new WaitForSeconds(clip.GetClip("down").length);
        Destroy(list);
        Spawn_list();
    }

    private void game_over() {
        Destroy(list);
        Instantiate(end_menu, new Vector2(540, 960), Quaternion.identity);
        timer_flag = true;
    }

    private void good_svaip() {
        timer += 1;
        test += 0.05f;
        score++;
        score_text.text = score.ToString();
    }

    private void show_preview() {
        switch (select_list)
        {
            case 1:
               // preview_image.color = new Color(0, 0, 0, 1);
               // break;
            case 2:
                preview_image.color = new Color32(157, 103, 91, 255);
                break;
            case 3:
                preview_image.color = new Color32(68, 123, 167, 255);
                break;
        }
    }
}
