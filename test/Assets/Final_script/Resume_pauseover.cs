using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_pauseover : MonoBehaviour
{
    private GameObject r;
    private Game game;
    private void Update() {

        r = GameObject.FindGameObjectWithTag("gameover");
        if (r == null)
        {
            game = GameObject.FindWithTag("panel").GetComponent<Game>();
            game.enabled = true;
            
        }
    }
}
