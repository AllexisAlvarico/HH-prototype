using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChange : MonoBehaviour
{

    // get shit here
    // buttons that does stuff
    // change scenes buttons
    // turn off buttons when pressed

    public void ActiveOff(GameObject @object)
    {
        @object.SetActive(false);
    }
}
