using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aircraftManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject plane;
    [SerializeField]
    private GameObject gameplay;
    [SerializeField]
    private Sprite[] aircraftSprite;
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

    public void EasyLevel()
    {
        amountOfPlane = 6;
        gameObject.SetActive(true);

    }
    public void MediumLevel()
    {
        amountOfPlane = 12;
        gameObject.SetActive(true);
    }
    public void HardLevel()
    {
        amountOfPlane = 18;
        gameObject.SetActive(true);
    }
}


