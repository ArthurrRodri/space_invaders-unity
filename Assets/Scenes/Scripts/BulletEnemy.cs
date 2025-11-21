using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private float speed; 

    private void Start() => Destroy(this.gameObject, 10f);
    void FixedUpdate() => Move();

    private void Move()
    {
        transform.position += new Vector3(0f, -1f, 0f) * speed * Time.deltaTime;
    }
}
