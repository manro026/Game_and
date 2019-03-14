using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour
{
    public float fall_speed = 22f;
    public GameObject list;
    private Animation clip;
    private GameObject test;
    private void Start()
    {
        clip = GetComponent<Animation>();
        clip.Play("start_down");
    }
    void Update()
    {
        //if (transform.position.y>4)
        //transform.position -= new Vector3(0, fall_speed * Time.deltaTime, 0);
    }   
}
