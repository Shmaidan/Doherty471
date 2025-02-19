using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    private enum State
    {
        Pace,
        Follow
    }

    [SerializeField]
    GameObject[] route;
    GameObject target;
    int routeIndex = 0;
    [SerializeField]
    float speed = 3.0f;


    private State currentState = State.Pace;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case State.Pace:
                OnPace();
                break;
            case State.Follow:
                OnFollow();
                break;
        }
    }
    void OnPace()
    {
        //what do we do when pacing?
        print("I'm pacing!");
        target = route[routeIndex];
        MoveTo(target);
       
        if (Vector3.Distance(transform.position, target.transform.position) < 0.1)
        {
            routeIndex += 1;

            if (routeIndex >= route.Length)
            {
                routeIndex = 0;
            }
        }
         //on what condition do we switch states?
        GameObject obstacle= CheckForward();
        if (obstacle != null)
        {
            target = obstacle; 
            currentState = State.Follow;
        }

       
    }

    void OnFollow()
    {
        //what do we do when following?
        print("I'm Following");
        MoveTo(target);

        //on what condition do stop follow?

        GameObject obstacle = CheckForward();

        if(obstacle == null)
        {
            currentState = State.Pace;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }

    void MoveTo(GameObject t)
    {
        transform.position = Vector3.MoveTowards(transform.position, t.transform.position, speed * Time.deltaTime);
        transform.LookAt(t.transform, Vector3.up); 

    }
    GameObject CheckForward()
    {
        RaycastHit hit;
        
        
        if(Physics.Raycast(transform.position, transform.forward, out hit, 13))
        {
            FirstPersonController player = hit.transform.gameObject.GetComponent<FirstPersonController>();
            if (player != null)
            {
                print(hit.transform.gameObject.name);
                return hit.transform.gameObject;
            }
        }

        return null;
    }
}
