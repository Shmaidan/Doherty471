using UnityEngine;

public class Treasure : MonoBehaviour
{

    [SerializeField]
    Manager manager;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerStateManager>() != null)
        {
            manager.EndGame();
        }
    }
}

