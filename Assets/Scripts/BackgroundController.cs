using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private SwipeController swipeController = new SwipeController();

    // Update is called once per frame
    void Update()
    {
        swipeController.swipe(transform);
    }
}
