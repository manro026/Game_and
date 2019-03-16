using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_pause1 : MonoBehaviour
{
    private GameObject s;
    private Game game;
    private void Update() {

        s = GameObject.FindGameObjectWithTag("pausemenu");
        if (s == null)
        {
            game = GameObject.FindWithTag("panel").GetComponent<Game>();
            game.enabled = true;
        }
    }
}
