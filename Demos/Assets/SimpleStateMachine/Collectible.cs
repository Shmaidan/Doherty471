using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;




    public class Collectible : MonoBehaviour
    {

     
    void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Object.FindFirstObjectByType<GameManager>().CollectItem();
                
                Destroy(gameObject);
                
          
            }
        }
    }
