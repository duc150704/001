using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovements : MonoBehaviour
{

    [SerializeField] float speed;
    
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z - gameObject.transform.position.z); 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, worldPos, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enermy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            
        }
    }
}
