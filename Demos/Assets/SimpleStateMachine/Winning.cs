using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int totalCollectibles = 5; // Number of collectibles required
    private int collectedCount = 0;
    public GameObject uiObject;
    public float resetDelay = 2f;
    void Start()
    {
        uiObject.SetActive(false);
    }
    public void CollectItem()
    {
        collectedCount++;
        Debug.Log("Collected: " + collectedCount + "/" + totalCollectibles);

        if (collectedCount >= totalCollectibles)
        {
            uiObject.SetActive(true);
            StartCoroutine(ResetSceneWithDelay());
            
        }
    }

    IEnumerator ResetSceneWithDelay()
    {
        Debug.Log("All collectibles collected! You win!");
        yield return new WaitForSeconds(resetDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
        
    
