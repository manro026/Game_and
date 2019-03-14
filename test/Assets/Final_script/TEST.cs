using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public GameObject s;
    public Animation clip;
    private GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
        clone = Instantiate(s);
        clone.GetComponent<Animator>();


        StartCoroutine(spaw());
        StartCoroutine(down_list());
    }

    private void OnMouseDown()
    {
        StartCoroutine(down_list());
    }

    private void Spawn_list()
    {
         int select_list = Random.Range(1, 4);
        switch (select_list)
        {
            case 1:
                Instantiate(s, new Vector2(0, 60), Quaternion.identity);
                StartCoroutine(down_list());
                break;
            case 2:
                Instantiate(s, new Vector2(0, 60), Quaternion.identity);
                StartCoroutine(down_list());
                break;
            case 3:
                Instantiate(s, new Vector2(0, 60), Quaternion.identity);
                StartCoroutine(down_list());
                break;
        }
    }
    IEnumerator down_list()
    {
        clip.Play("start_down");
        yield return new WaitForSeconds(1);
    }
    IEnumerator spaw()
    {
        Instantiate(clone, new Vector2(0, 60), Quaternion.identity);
        yield return new WaitForSeconds(1);
    }
}
