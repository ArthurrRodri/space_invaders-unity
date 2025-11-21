using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D _rb;
    public float health;
    
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        Moviment();
    }

    private void Moviment()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var movement = new Vector3(horizontal, 0f, 0f).normalized;
        
        if (movement != Vector3.zero)
        {
            _rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
        }
    }
}
