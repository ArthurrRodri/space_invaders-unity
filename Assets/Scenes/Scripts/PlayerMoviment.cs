using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float cooldown_;
    [SerializeField] private float duration_;

    bool isDead;
    bool isHit;

    void FixedUpdate()
    {
        Moviment();
        BulletInstante();
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

    private void BulletInstante()
    { 
        if (Input.GetKey(KeyCode.Space) && isHit)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            isHit = false;
            cooldown_ = 0f;
        }
        Cooldown();
    }

    private void Cooldown()
    {
        if (cooldown_ > duration_)
        {
            isHit = true;
        }
        else
        {
            cooldown_ += Time.deltaTime;
        }
    }
}
