using UnityEngine;

public class Pin : MonoBehaviour
{
    public float speed = 30f;
    private Rigidbody2D rigidbody2D;
    private bool isPinned = false;
    private GameManager gameManager;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (!isPinned) rigidbody2D.MovePosition(rigidbody2D.position + Vector2.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rotator>())
        {
            isPinned = true;
            collision.GetComponent<Rotator>().ChangeSpeedByMode();
            Score.PinCount += 1;
            transform.SetParent(collision.transform);
        } else if (collision.GetComponent<Pin>())
        {
            gameManager.EndGame();
        }
    }
}
