using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController
{
    Vector2 firstPressPosition;
    Vector2 secondPressPosition;
    Vector2 currentSwipe;

    public Vector2 swipe(Transform transform, float swipeSpeed, bool verticalScrolling = false,
     bool horizontalScrolling = true)
    {
        // if (Input.touches.Length > 0)
        // {
        //     Touch touch = Input.GetTouch(0);

        if (Input.GetMouseButtonDown(0))
        {
            firstPressPosition = Input.mousePosition;
            secondPressPosition = Input.mousePosition;
        }

        else if (Input.GetMouseButton(0))
        {
            secondPressPosition = Input.mousePosition;

            currentSwipe = new Vector2(secondPressPosition.x - firstPressPosition.x,
            secondPressPosition.y - firstPressPosition.y);

            Vector2 finalSwipe = currentSwipe.normalized;
            Debug.Log(currentSwipe);

            float finalSpeed = (swipeSpeed + finalSwipe.magnitude) * Time.deltaTime;

            if (horizontalScrolling && verticalScrolling) return currentSwipe * finalSpeed;
            if (horizontalScrolling) return new Vector2(currentSwipe.x, 0.0f) * finalSpeed;
            if (verticalScrolling) return new Vector2(0.0f, currentSwipe.y) * finalSpeed;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            firstPressPosition = Vector2.zero;
            secondPressPosition = Vector2.zero;
            currentSwipe = Vector2.zero;
        }
        // }

        return Vector2.zero;
    }
}
