using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private SwipeController swipeController = new SwipeController();

    private Vector2 imageConstraintMin;
    private Vector2 imageConstraintMax;

    public int contraintOffset;
    void Start()
    {
        Debug.Log(Screen.width);
        imageConstraintMin = new Vector2(GetComponent<SpriteRenderer>().bounds.min.x + contraintOffset,
         GetComponent<SpriteRenderer>().bounds.min.y);

        imageConstraintMax = new Vector2(GetComponent<SpriteRenderer>().bounds.max.x - contraintOffset,
         GetComponent<SpriteRenderer>().bounds.max.y);
    }
    // Update is called once per frame
    void Update()
    {
        // alter swipe function to return the value of the swipe in a given direction
        // could use min() to setup contraints for the background image
        // so that the user won't be able to swipe away the image
        transform.Translate(swipeController.swipe(transform) * Time.deltaTime);
        // Debug.Log(transform.position.x + "min: " + imageConstraintMin.x + "," + imageConstraintMax.x);
        Vector2 tempPosition = transform.position;
        tempPosition.x = Mathf.Clamp(tempPosition.x, imageConstraintMin.x, imageConstraintMax.x);
        tempPosition.y = Mathf.Clamp(tempPosition.y, imageConstraintMin.y, imageConstraintMax.y);
        transform.position = tempPosition;
        // Debug.Log("clamped pos: " + tempPosition);
    }

    private float divideValue(float value, float divideBy)
    {
        return value / divideBy;
    }
}
