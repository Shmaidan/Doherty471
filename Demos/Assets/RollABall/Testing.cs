using UnityEngine;
using UnityEngine.SceneManagement;
public class Testing : MonoBehaviour
{

    public GameObject cube;
    Transform t;
    float speed = 0.01f;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = cube.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (t.position.y > 12){
            speed = speed * -1;
        } else if (t.position.y < 8)
        {
            speed = speed * -1;
        }
        t.Translate(0, speed, 0);
        
    }
}

