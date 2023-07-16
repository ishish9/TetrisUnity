using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float ForwardSpeed;
 
    [SerializeField] private GameObject Prefab;
    [SerializeField] private BlockScriptable BlockAudio;
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

        // Controls      

        if (Input.GetKey("down"))
        {
            elapsed += Time.deltaTime * 2;

        }

        if (Input.GetKeyDown("left"))
        {
            if (MovementStep == -3)
            {
                CubeManager.instance.reachedEnd.Play();
            }
            else
            {
                MovementStep += - 1;
                transform.position = transform.position + new Vector3(-1, 0, 0);
                CubeManager.instance.move.Play();
            }
        }

        if (Input.GetKeyDown("right"))
        {
            if (MovementStep == 3)
            {
                CubeManager.instance.reachedEnd.Play();
            }
            else
            {
                MovementStep += +1;
                transform.position = transform.position + new Vector3(1, 0, 0);
                CubeManager.instance.move.Play();
            }

        }

        if (Input.GetKeyDown("down"))
        {       
            transform.position = transform.position + new Vector3(0, -1, 0);
            CubeManager.instance.move.Play();
        }

        if (Input.GetKeyDown("a"))
        {
            transform.Rotate(0f, 0f, 90f, Space.Self);
            CubeManager.instance.RotateSound.Play();

        }

        if (Input.GetKeyDown("s"))
        {
            transform.Rotate(0f, 0f, -90f, Space.Self);
            CubeManager.instance.RotateSound.Play();
        }
    }
    //On Screen Controls
    public void Right()
    {
        if (MovementStep == 3)
        {
            CubeManager.instance.reachedEnd.Play();
        }
        else
        {
            MovementStep = MovementStep + 1;
            transform.position = transform.position + new Vector3(1, 0, 0);
            CubeManager.instance.move.Play();
        }
    }

    public void Left()
    {
        if (MovementStep == -3)
        {
            CubeManager.instance.reachedEnd.Play();
        }
        else
        {
            MovementStep = MovementStep - 1;
            transform.position = transform.position + new Vector3(-1, 0, 0);
            CubeManager.instance.move.Play();
        }
    }

    private void OnTriggerEnter(Collider Col)
    {
        CubeManager.instance.BlockSetSound.Play();
        GetComponent<Controller>().enabled = false;
        Instantiate(CubeManager.instance.BlockArray[CubeManager.instance.SelectedCube], CubeManager.instance.BlockSpawnLocation.position, Quaternion.identity);
    }
}
