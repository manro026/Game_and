using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_anim_trap : MonoBehaviour
{
    private Animation clip;
    void Start()
    {
        clip = GetComponent<Animation>();
        clip.Play("trig");
    }
    
}
