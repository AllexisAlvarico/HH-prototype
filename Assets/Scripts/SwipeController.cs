using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController
{
    Vector2 firstPressPosition;
    Vector2 secondPressPosition;
    Vector2 currentSwipe;

    public void swipe(Transform transform)
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstPressPosition = new Vector2(touch.position.x, touch.position.y);
            }

            if (touch.phase == TouchPhase.Moved)
            {
                secondPressPosition = new Vector2(touch.position.x, touch.position.y);

                currentSwipe = new Vector2(secondPressPosition.x - firstPressPosition.x,
                secondPressPosition.x - firstPressPosition.x);

                currentSwipe.Normalize();
                transform.Translate(currentSwipe);
                Debug.Log(currentSwipe);

                // if (currentSwipe.y > 0 && currentSwipe.x > -0.71f && currentSwipe.x < 0.71f)
                // {
                //     //Debug.Log("up Swipe");
                // }
                // if (currentSwipe.y < 0 && currentSwipe.x > -0.71f && currentSwipe.x < 0.71f)
                // {
                //     //Debug.Log("down Swipe");
                // }
                // if (currentSwipe.x < 0 && currentSwipe.y > -0.71f && currentSwipe.y < 0.71f)
                // {
                //     // Debug.Log("left Swipe");
                // }
                // if (currentSwipe.x > 0 && currentSwipe.y > -0.71f && currentSwipe.y < 0.71f)
                // {
                //     // Debug.Log("right Swipe");
                // }
            }
        }
    }
}
