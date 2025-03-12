using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float bulletspeed = 6;
    [SerializeField]
    float lifetime = 3;
    private bool hasPowerup = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
  
    void Update()
    {
        
        
        rb.AddForce(transform.forward * bulletspeed);
       
        
    }
}
