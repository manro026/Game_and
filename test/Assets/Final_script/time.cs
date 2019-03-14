using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    public float timer = 10f;
    public Text timer_text;
    public GameObject ends;
    private bool Create = true;
    // Start is called before the first frame update
    void Start()
    {
        timer_text.text = timer.ToString();  
    }

    // Update is called once per frame
    void Update()
    {
       
        if(timer<0)
        {
            if (!Create)
            {
                Create = true;
                Instantiate(ends, new Vector2(0, 0), Quaternion.identity);
            }

            timer_text.text = "Game Over";
        }
        else
        {
            timer -= Time.deltaTime;
            timer_text.text = timer.ToString();
            Create = false;

        }
    }
}
