using UnityEngine;

public class xMoveLeft : MonoBehaviour
{
    public GameObject cube1;
    Transform t;
    float speed = 0.02f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = cube1.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (t.position.x > 9)
        {
            speed = speed * -1;
        }
        else if (t.position.x < 2)
        {
            speed = speed * -1;
        }
        t.Translate(speed, 0, 0);

    }
}
