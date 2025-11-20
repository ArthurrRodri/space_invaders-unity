using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject laser_;
    [SerializeField] private float cooldown_;
    [SerializeField] private float duration_;
    bool isHit;

    private void FixedUpdate() => BulletInstante();

    private void BulletInstante()
    {
        if (Input.GetKey(KeyCode.Space) && isHit)
        {
            Instantiate(bulletPrefab, laser_.transform.position, Quaternion.identity);
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
