using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aircraftManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject plane;
    [SerializeField]
    private Sprite[] aircraftSprite;
    [SerializeField]
    private int amountOfPlane;
    Vector3 position;

    void Start()
    {
        for (int i = 0; i < amountOfPlane; i++)
        {
            position = new Vector3(Random.Range(-3.91f, 3.79f), Random.Range(-3.92f, 3.75f), 0);
            plane.GetComponent<PlaneType>().spawnPlane(plane, position, i);
        }
    }

    public Sprite setSprite(int type)
    {
        return aircraftSprite[type];
    }

    public int GetAmountOfPlane()
    {
        return amountOfPlane;
    }
}
