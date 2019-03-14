using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnList : MonoBehaviour
{
    public GameObject black;
    public GameObject blue;
    public GameObject red;
    public float select_list;
    void Start()
    {
        select_list = Random.Range(1, 4);
        switch(select_list)
        {
            case 1:
                Instantiate(black, new Vector2(0, 60), Quaternion.identity);
                break;
            case 2:
                Instantiate(red, new Vector2(0, 60), Quaternion.identity);
                break;
            case 3:
                Instantiate(blue, new Vector2(0, 60), Quaternion.identity);
                break;
        }       
        //StartCoroutine(Spawn());
    }

    /*IEnumerator Spawn()
    {
        while(true)
        { Vector2 pos;
            if(time_down>0.2f)
                time_down -= Time.deltaTime;
            Instantiate(list, new Vector2(0,8), Quaternion.identity);
            yield return new WaitForSeconds(time_down);
        }
    }*/
}
