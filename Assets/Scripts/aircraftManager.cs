using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aircraftManager : MonoBehaviour
{
    public GameObject plane;
    public string currentDifficulty;
    [SerializeField]
    private GameObject gameplay;
    [SerializeField]
    private GameObject radarCircle;
    [SerializeField]
    private Sprite[] aircraftSprite;
    private int amountOfPlane;
    Vector3 position;
    private float radarRadius = 4.3f;

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
        GameStart();
        gameplay.SetActive(true);
        currentDifficulty = "Easy";

    }
    public void MediumLevel()
    {
        amountOfPlane = 12;
        GameStart();
        gameplay.SetActive(true);
        currentDifficulty = "Medium";
    }
    public void HardLevel()
    {
        amountOfPlane = 18;
        GameStart();
        gameplay.SetActive(true);
        currentDifficulty = "Hard";
    }

    private void GameStart()
    {
        for (int i = 0; i < amountOfPlane; i++)
        {
            position = new Vector3(Random.Range(-3.91f, 3.79f), Random.Range(-3.92f, 3.75f), 0);
            if(Vector2.Distance(radarCircle.transform.position, position) > radarRadius)
            {
                float angle = Mathf.Asin(position.x / Vector2.Distance(radarCircle.transform.position, position));
                position.x = radarRadius * Mathf.Sin(angle);
                position.y = radarRadius * Mathf.Cos(angle);
            }
            plane.GetComponent<PlaneType>().spawnPlane(plane, position, i);
        }
    }
}


