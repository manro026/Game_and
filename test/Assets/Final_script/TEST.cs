using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    private GameObject s;
    private Game game;
    private void Update() {

        s = GameObject.FindGameObjectWithTag("pausemenu");
        if (s ==null )
        {
            game = GameObject.FindWithTag("Respawn").GetComponent<Game>();
            game.enabled = true;
        }
    }
}
