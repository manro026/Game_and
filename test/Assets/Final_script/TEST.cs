using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public GameObject s;
    public GameObject s12;
    public Animation clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        
        //Instantiate(s, new Vector2(120, 720), Quaternion.identity);
        s12 = Instantiate(s);
        StartCoroutine(down_list());
        
    }
    
    IEnumerator down_list()
    {
        clip = s12.GetComponent<Animation>();
        clip.Play("mini_down");
        yield return new WaitForSeconds(clip.GetClip("mini_down").length);
        Destroy(s12);
    }   
}
