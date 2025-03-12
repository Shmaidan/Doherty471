using UnityEngine;


public class BigEnemyScript : MonoBehaviour
{
    int health = 10;
    public ParticleSystem BigBloodParticles;
    // public AudioSource death;


    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        //death = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {

            // death.Play();
            Instantiate(BigBloodParticles, transform.position, Quaternion.identity);
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