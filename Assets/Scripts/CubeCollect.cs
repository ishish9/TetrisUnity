using UnityEngine;

public class CubeCollect : MonoBehaviour
{
    [SerializeField] private AudioSource CoinCollectedSound;
    [SerializeField] private GameObject Prefab;
    [SerializeField] private Score script1;

    void Update()
    {
        transform.Rotate(0f, 200f * Time.deltaTime, 0f, Space.Self);
    }

    private void OnTriggerEnter()
    {
        //CoinCollectedSound.Play();
        Instantiate(Prefab, transform.position, transform.rotation);
        script1.ScoreAdd1();
        script1.Scoreupdate();
        gameObject.SetActive(false);       
    }
}
