
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletSpeed = 15f;

    void Update()
    {
        if (Mouse.current == null)
            return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
            return;

        Camera cam = Camera.main;

        if (cam == null)
            return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Vector3 mouseWorld = cam.ScreenToWorldPoint(
            new Vector3(mousePosition.x, mousePosition.y, -cam.transform.position.z)
        );

        Vector2 direction = ((Vector2)mouseWorld - (Vector2)firePoint.position).normalized;

        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity
        );

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = direction * bulletSpeed;
        }
    }
}
