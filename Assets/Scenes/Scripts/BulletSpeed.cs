using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start() => Destroy(gameObject, 5f);



    private void FixedUpdate() => transform.position += new Vector3(0f, 1f, 0f) * speed * Time.deltaTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyBehavior>().health -= 1;
            Destroy(this.gameObject);
        }
    }

}
