using UnityEditor.Timeline;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float delay;
    [SerializeField] private float duration;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private bool moveRight;
    public float health; 

    bool moving;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void FixedUpdate() => move();

    private void move()
    {
        var movement = new Vector3(1f, 0f, 0f).normalized;

        if (moving && moveRight)
        {
            movement = new Vector3(1f, 0f, 0f).normalized;
            _rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
            moving = false;

        }
        else if(moving && !moveRight)
        {
            movement = new Vector3(-1f, 0f, 0f).normalized;
            _rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
            moving = false;
        }
        cooldown(); 

    }

    private void cooldown()
    {
        if (delay > duration)
        {
            moving = true;
            delay = 0;
        }
        else
        {
           delay += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WallLeft"))
        {
            moveRight = true;
            transform.position -= new Vector3(0f,1f,0f);
           
        }
        if (collision.CompareTag("WallRight"))
        {
            moveRight = false;
            transform.position -= new Vector3(0f, 1f, 0f);
        }
    }

}
