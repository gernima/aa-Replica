using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    public GameObject pinPrefab;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && GameManager.gameStarted)
        {
            if (GameManager.tapToPlay.activeSelf)
            {
                GameManager.tapToPlay.SetActive(false);
            }
            SpawnPin();
        }
    }
    void SpawnPin()
    {
        Instantiate(pinPrefab, transform.position, transform.rotation);
    }
}
