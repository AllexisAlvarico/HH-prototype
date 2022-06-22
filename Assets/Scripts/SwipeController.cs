using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController
{
    Vector2 firstPressPosition;
    Vector2 secondPressPosition;
    Vector2 currentSwipe;
    float swipeSpeed = 5.0f;
    float slowDownScalar = 0.98f;

    public Vector2 swipe(Transform transform, bool verticalScrolling = false,
     bool horizontalScrolling = true)
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstPressPosition = new Vector2(touch.position.x, touch.position.y);
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                secondPressPosition = new Vector2(touch.position.x, touch.position.y);

                currentSwipe = new Vector2(secondPressPosition.x - firstPressPosition.x,
                secondPressPosition.y - firstPressPosition.y);

                Vector2 finalSwipe = currentSwipe.normalized;
                Debug.Log(currentSwipe);

                float finalSpeed = (swipeSpeed + finalSwipe.magnitude) * Time.deltaTime;

                if (horizontalScrolling && verticalScrolling) return currentSwipe * finalSpeed;
                if (horizontalScrolling) return new Vector2(currentSwipe.x, 0.0f) * finalSpeed;
                if (verticalScrolling) return new Vector2(0.0f, currentSwipe.y) * finalSpeed;
            }

            else if (touch.phase == TouchPhase.Stationary)
            {
                return Vector2.zero;
            }
        }

        return Vector2.zero;
    }
}
