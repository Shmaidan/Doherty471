using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    public float bulletspeed = 12;
    [SerializeField]
    float lifetime = 3;
   
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
