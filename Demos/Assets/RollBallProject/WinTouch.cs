using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTouch : MonoBehaviour
{
    public GameObject uiObject;
    void Start()
    {
        uiObject.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            SceneManager.LoadScene(0); // Reload the current scene

        }
    }
}
