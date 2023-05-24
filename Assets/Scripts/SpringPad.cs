using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPad : MonoBehaviour
{
    [SerializeField] private AudioSource Springsnd;
    [SerializeField] private Controller script1;  

    void OnTriggerEnter()
    {
        Springsnd.Play();
        //script1.SpringTrue();
    }
}
