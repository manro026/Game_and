using UnityEngine;
public class Pause : MonoBehaviour
{
    public Game game;

    public GameObject pausemenu;

    private void OnMouseDown()
    {

        Instantiate(pausemenu, new Vector2(540, 960), Quaternion.identity);
        game.enabled = false;
    }
}
