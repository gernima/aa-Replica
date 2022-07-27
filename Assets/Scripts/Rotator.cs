using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 100f;
    private int mode;

    private void Start()
    {
        mode = Random.Range(1, 4);
    }
    private void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
    public void ChangeSpeedByMode()
    {
        switch (mode)
        {
            case 1:
                speed += 10f;
                break;
            case 2:
                speed += 10f;
                speed *= -1f;
                break;
            case 3:
                speed *= 1.05f;
                break;
            case 4:
                speed *= -1.05f;
                break;

        }
    }
}
