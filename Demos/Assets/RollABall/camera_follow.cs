using UnityEngine;

public class camera_follow : MonoBehaviour
{
    Vector3 offset;

    Vector3 newpos;

    public GameObject player;

    void Start()
    {
        offset = player.transform.position - transform.position;
    }

    private void Update()
    {
        transform.position = player.transform.position-offset;
    }
}


