using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float ForwardSpeed;
    [SerializeField] private AudioSource move;
    [SerializeField] private AudioSource reachedEnd;
    [SerializeField] private GameObject Prefab;
    [SerializeField] private Score script1;
    private int MovementStep = 0;
    private float elapsed = 0f;
    private bool active = true;

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            transform.position = transform.position + new Vector3(0, -1, 0);
        }

        RaycastHit hit;
        // Move Forward
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3 forward = transform.TransformDirection(Vector3.forward) * .5f;
        //Debug.DrawRay(transform.position, forward, Color.red);
        if (Physics.Raycast(transform.position, Vector3.down, .6f))
        {
            //active = false;
            Debug.Log("On Ground");    
        }
        else
        {
            Debug.Log("Not On Ground");
        }

        // Controls
        if (Input.GetKeyDown("right"))
        {
            if (MovementStep == 3)
            {
                reachedEnd.Play();
            }
            else
            {
                MovementStep += + 1;
                transform.position = transform.position + new Vector3(1, 0, 0);
                move.Play();
            }
           
        }

        if (Input.GetKeyDown("left"))
        {
            if (MovementStep == -3)
            {
                reachedEnd.Play();
            }
            else
            {
                MovementStep += - 1;
                transform.position = transform.position + new Vector3(-1, 0, 0);
                move.Play();
            } 
        }

        if (Input.GetKeyDown("down"))
        {       
            transform.position = transform.position + new Vector3(0, -1, 0);
            move.Play();
        }

        if (Input.GetKeyDown("a"))
        {
            transform.Rotate(0f, 0f, 90f, Space.Self);
            move.Play();
        }

        if (Input.GetKeyDown("s"))
        {
            transform.Rotate(0f, 0f, -90f, Space.Self);
            move.Play();        
        }
    }

    public void Right()
    {
        if (MovementStep == 3)
        {
            reachedEnd.Play();
        }
        else
        {
            MovementStep = MovementStep + 1;
            transform.position = transform.position + new Vector3(1, 0, 0);
            move.Play();
        }
    }

    public void Left()
    {
        if (MovementStep == -3)
        {
            reachedEnd.Play();
        }
        else
        {
            MovementStep = MovementStep - 1;
            transform.position = transform.position + new Vector3(-1, 0, 0);
            move.Play();
        }
    }
}
