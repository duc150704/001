using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    Rigidbody2D rb;
    [SerializeField] float knockBackForce;

    [SerializeField] Transform shootingPoint;


    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    void Shoot()
    {  
        if (InputManager.Instance.IsShootingPressed())
        {
            GameObject newbull = Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            AudioManager.Instance.PlayShootingSound();
            rb.AddForce(knockBackForce * Vector2.down, ForceMode2D.Impulse);
            Physics2D.IgnoreCollision(newbull.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            StartCoroutine(StopKnockBack());
            Destroy(newbull, 3);
        }

    }

    IEnumerator StopKnockBack()
    {
        yield return new WaitForSeconds(0.1f);
        rb.velocity = Vector2.zero;
    }

}
