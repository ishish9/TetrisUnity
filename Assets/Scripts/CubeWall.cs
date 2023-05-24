using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeWall : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Prefab;

    private void OnTriggerEnter()
    {
        Player.SetActive(false);
        Instantiate(Prefab, Player.transform.position, transform.rotation);
    }
}
