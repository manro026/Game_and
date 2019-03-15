using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
public class Game : MonoBehaviour {
    public GameObject list_red;
    public GameObject list_blue;
    public GameObject end_menu;
    public GameObject mini_left;
    public GameObject mini_right;
    public GameObject list;
    public GameObject mini_list;
    private Animation mini_clip;
    private Animation clip;
    private int select_list;
    public float timer = 25f;
    private bool timer_flag = true;
    public Slider slider_time;
    private int score;
    public Text score_text;
    private bool preview_flag;
    private float preview;
    public Image preview_image;
    private float test;
    public AudioClip audiO;
    public float volume;
    private AudioSource audio_sourse;

    
    internal void Start() {
        preview_flag = true;
        select_list = Random.Range(1, 3);
        Spawn_list();
        audio_sourse = GetComponent<AudioSource>();
       
    }

    internal void Update() {
        int score_save;
        score_save = PlayerPrefs.GetInt("score_save");
        if (score_save < score)
            PlayerPrefs.SetInt("score_save", score);
        {
            if (!timer_flag && timer > 0)
            {//таймер
                timer -= (Time.deltaTime * test);
                slider_time.value = timer;
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    switch (touch.phase)
                    {

                        case TouchPhase.Began:
                            if (touch.position.x > 540)
                            {
                                if (preview == 1)
                                {
                                    StartCoroutine(svaip_list_right());
                                    good_svaip();
                                    StartCoroutine(mini_svaip_right());
                                }
                                else
                                    game_over();
                            }
                            else
                            {
                                if (preview == 2)
                                {
                                    StartCoroutine(svaip_list_left());
                                    good_svaip();
                                    StartCoroutine(mini_svaip_left());
                                }
                                else
                                    game_over();
                            }
                            break;
                    }
                }
            }
            else if (0 > timer)
            {
                game_over();
            }
        }
    }

    private void Spawn_list() {
        timer_flag = false;
        preview = select_list;
        switch (select_list)
        {
            case 1:
                list = Instantiate(list_red);
                StartCoroutine(down_list());
                break;
            case 2:
                list = Instantiate(list_blue);
                StartCoroutine(down_list());
                break;
        }
        if (!preview_flag)
            select_list = Random.Range(1, 3);
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
        audio_sourse.PlayOneShot(audiO, volume);
        clip = list.GetComponent<Animation>();
        clip.Play("right");
        yield return new WaitForSeconds(clip.GetClip("right").length);
        Destroy(list);
        Spawn_list();
    }  

    internal IEnumerator mini_svaip_left() {

        mini_list = Instantiate(mini_left);
        mini_clip = mini_list.GetComponent<Animation>();
        mini_clip.Play("mini_down");
        yield return new WaitForSeconds(mini_clip.GetClip("mini_down").length);

    }
    internal IEnumerator mini_svaip_right() {

        mini_list = Instantiate(mini_right);
        mini_clip = mini_list.GetComponent<Animation>();
        mini_clip.Play("xf");
        yield return new WaitForSeconds(mini_clip.GetClip("xf").length);
    }
    private void game_over() {
        Destroy(list);
        Instantiate(end_menu, new Vector2(540, 960), Quaternion.identity);
        timer_flag = true;
    }

    private void good_svaip() {
        timer += 1;
        test += 0.02f;
        score++;
        score_text.text = score.ToString();
       
    }

    private void show_preview() {
        switch (select_list)
        {
            case 1:
                preview_image.color = new Color32(114, 92, 94, 255);
                break;
            case 2:
                preview_image.color = new Color32(75, 97, 110, 255);
                break;
        }
    }
}
