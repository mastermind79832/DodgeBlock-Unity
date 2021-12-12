using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{


    public float speed = 15f;

    private Rigidbody2D rb;
    
    public GameObject gameManager;
    
    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();

        

    }
   
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed; 
         if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0f;

            if(touch.phase == TouchPhase.Stationary)
            {
                if(touchPos.x > 0)
                    x = 1f;
                else if (touchPos.x < 0)
                    x = -1f;
            }
            if(touch.phase == TouchPhase.Ended)
                x = 0f;
        }

        Vector2 newPos = rb.position + Vector2.right * x;
        

        newPos.x = Mathf.Clamp(newPos.x, -2.2f, 2.2f);

        rb.MovePosition(newPos);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.parent.tag == "Block")
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }




    }


}
