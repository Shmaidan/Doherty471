using UnityEngine;

public class HidingNinja : MonoBehaviour
{
    public GameObject cube1;
    Transform t;
    float speed = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = cube1.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (t.position.y > 2)
        {
            speed = speed * -1;
        }
        else if (t.position.y < -1.5)
        {
            speed = speed * -1;
        }
        t.Translate(0, speed, 0);

    }
}