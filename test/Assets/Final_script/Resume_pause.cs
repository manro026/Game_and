using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_pause : MonoBehaviour
{
    public Game game;
    private void Start()
    {
        game = GameObject.FindWithTag("Respawn").GetComponent<Game>();
    }
    private void OnMouseDown()
    {
        game.enabled = true;
        Destroy(gameObject);
    }
}
