using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    public Game game;
    public GameObject pausemenu;
    private GameObject pause;
    private bool isClick=true;
    private void OnMouseDown()
    {
       if(isClick==true)
        {
            
            game.pause = true;
            isClick = false;
            pause=Instantiate(pausemenu, new Vector2(540, 960), Quaternion.identity);

        }
       

    }
    void Update(){
        if(isClick==true)
        {   Destroy(pause);
            game.pause = false;
            isClick = true;
        }
    }
}
