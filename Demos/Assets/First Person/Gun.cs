using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] float rateOfFire = 1f;

    public float GetRateOfFire()
    {
        return rateOfFire;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Fire()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}

   
