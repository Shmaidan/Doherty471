using Unity.VisualScripting;
using UnityEngine;

public class EnemyShooters : MonoBehaviour
{

    [SerializeField] float shootRange = 20f;
    [SerializeField]
    float shootRotateSpeed = 5;

    private Transform playerTransform;
    private Gun currentGun;
    private float fireRate;
    private float fireRateDelta;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = FindObjectOfType<FirstPersonController>().transform;
        currentGun = GetComponentInChildren<Gun>();
        fireRate = currentGun.GetRateOfFire();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);

        if (Vector3.Distance(transform.position, playerPos) > shootRange)
        {
            return;
        }

        Vector3 playerDirection = playerPos = transform.position;
        float rotationStep = shootRotateSpeed * Time.deltaTime;
        Vector3 newLookDirection = Vector3.RotateTowards(transform.forward, playerDirection, rotationStep, 0f);

        transform.rotation = Quaternion.LookRotation(newLookDirection);

        fireRateDelta -= Time.deltaTime;
        if(fireRateDelta <= 0)
        {
            currentGun.Fire();
            fireRateDelta = fireRate;
        }
        
    }


}
