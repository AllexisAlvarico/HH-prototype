using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private SwipeController swipeController = new SwipeController();

    private Vector2 imageConstraintMin;
    private Vector2 imageConstraintMax;

    public int contraintOffsetHorizontal;
    public int contraintOffsetVertical;

    public float swipeSpeed = 20.0f;
    void Start()
    {
        Debug.Log(Screen.width);
        imageConstraintMin = new Vector2(GetComponent<SpriteRenderer>().bounds.min.x + contraintOffsetHorizontal,
         GetComponent<SpriteRenderer>().bounds.min.y + contraintOffsetVertical);

        imageConstraintMax = new Vector2(GetComponent<SpriteRenderer>().bounds.max.x - contraintOffsetHorizontal,
         GetComponent<SpriteRenderer>().bounds.max.y - contraintOffsetVertical);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(swipeController.swipe(transform, swipeSpeed, true) * Time.deltaTime);
        Vector2 tempPosition = transform.position;
        tempPosition.x = Mathf.Clamp(tempPosition.x, imageConstraintMin.x, imageConstraintMax.x);
        tempPosition.y = Mathf.Clamp(tempPosition.y, imageConstraintMin.y, imageConstraintMax.y);
        transform.position = tempPosition;
    }

    private float divideValue(float value, float divideBy)
    {
        return value / divideBy;
    }
}
