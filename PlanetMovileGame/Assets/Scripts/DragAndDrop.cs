using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndDrop : MonoBehaviour
{

    bool moveAllowed;
    Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //this gets the position touched into the screen into unity postition variables transformed from pixels
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            
            //when we touch the screen for the first time
            if (touch.phase==TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider)
                {
                    moveAllowed = true;
                }
            }
            //when our finger is still on the screen
            if (touch.phase == TouchPhase.Moved)
            {
                if (moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }
            //when we take our finger off the screen
            if (touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }



        }



    }
}
