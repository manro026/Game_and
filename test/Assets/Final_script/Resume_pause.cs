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
    private void OnMouseDown() {
        Destroy(gameObject);
       // StartCoroutine(Stop_time());     
    }
    IEnumerator Stop_time() {
        Debug.Log("SX_1");
       Destroy(gameObject);
        yield return new WaitForSeconds(2);
        game.enabled = true;
        Debug.Log("SX");
    }



}
