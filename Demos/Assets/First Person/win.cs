using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public GameObject youWinUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        youWinUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            ShowWinScreen();
            ReloadScene();
        }
        
    }
    void ShowWinScreen()
    {
        if (youWinUI != null)
        {
            youWinUI.SetActive(true); // Show the "You Win" UI
        }

    }
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }
}
