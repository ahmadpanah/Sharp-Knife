
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    private Rigidbody2D knifeRigidBody;
    [SerializeField] private float moveSpeed;

    private bool canShoot;

    private void Start()
    {
        GetComponentValues();
    }

    private void Update()
    {
        HandleShootInput();
    }

    private void FixedUpdate()
    {
        Shoot();
    }

    private void HandleShootInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canShoot = true;
        }
    }

    private void Shoot()
    {
        if (canShoot)
        {
            knifeRigidBody.AddForce(Vector2.up * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Circle"))
        {
            canShoot = false;
            knifeRigidBody.isKinematic = true;
            transform.SetParent(other.gameObject.transform);
        }
    }


    private void GetComponentValues()
    {
        knifeRigidBody = GetComponent<Rigidbody2D>();
    }
}