using UnityEngine;


public class enemy : MonoBehaviour
{
    int health = 4;
    public ParticleSystem bloodParticles;
    // public AudioSource death;
   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //death = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {

          // death.Play();
            Instantiate(bloodParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
            
            
        }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<bullet>() != null)
        {

            health -= 1;
           
            Destroy(other.gameObject);
        }
    }
    
}

