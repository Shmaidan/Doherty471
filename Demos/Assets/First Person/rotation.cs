using UnityEngine;
using UnityEngine;

public class rotation : MonoBehaviour

{
    
    public GameObject cube;
    Transform t;
    float speed = 0.02f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = cube.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (t.position.x > 47)
        {
            speed = speed * -1;
        }
        else if (t.position.x < 46)
        {
            speed = speed * -1;
        }
        t.Translate(speed, 0, 0);
    }
}