using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [SerializeField] Transform bg1;
    [SerializeField] Transform bg2;

    [SerializeField] Transform upPoint;
    [SerializeField] Transform downPoint;

    [SerializeField] float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        TakeHeight();
        //Debug.Log(upPoint.position.y.ToString());
    }

    //Update is called once per frame
    void Update()
    {
        Move();
    }

    void TakeHeight()
    {
        SpriteRenderer sr = bg1.GetComponent<SpriteRenderer>();

        float Height = sr.bounds.size.y;
        upPoint.position = Vector3.zero + new Vector3(0,Height -0.15f , 0);

        downPoint.position = Vector3.zero - new Vector3(0, Height , 0);

    }

    void Check()
    {
        if(bg1.position.y <= downPoint.position.y)
        {
            bg1.position = upPoint.position;
        }
        if (bg2.position.y <= downPoint.position.y)
        {
            bg2.position = upPoint.position;
        }

        
    }
    void Move()
    {
        Check();
        bg1.position += Vector3.down * speed * Time.deltaTime;
        bg2.position += Vector3.down * speed * Time.deltaTime;
    }
}
