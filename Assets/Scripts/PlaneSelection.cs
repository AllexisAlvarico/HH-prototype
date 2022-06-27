using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private RawImage rawImageObj;

    private int count;
    private int score;

    [SerializeField]
    private Text scoreText;

    private string planeData;
    private string planeName;
    private string answer;

    private float maxTimer = 3.0f;
    private float timer = 0;

    bool timerStart = false;
    public bool alliedSelected = false;
    public bool axisSelected = false;
    private bool planeSelected = false;

    private void Start()
    {
        count = 0;
        score = 0;

    }

    private void Update()
    {
        if (timerStart)
        {
            timer += Time.deltaTime;
        }

        if (timer > maxTimer)
        {
            panel.SetActive(false);
            timerStart = false;
            activeButtons();
            timer = 0;
            axisSelected = false;
            alliedSelected = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "RadarLine" && !planeSelected)
        {
            Debug.Log("Player Touched Plane ID: " + collision.gameObject.GetComponent<PlaneType>().getID());
            planeData = collision.gameObject.GetComponent<PlaneType>().getFaction();
            planeName = collision.gameObject.GetComponent<PlaneType>().getName();
            rawImageObj.texture = collision.gameObject.GetComponent<PlaneType>().getTexture();
            Destroy(collision.gameObject);
            panel.SetActive(true);
            planeSelected = true;
        }
    }

    public void checkAnswer()
    {
        if (planeData == "allied" && alliedSelected || planeData == "axis" && axisSelected)
        {
            score++;
            count++;
            answer = "Correct";
        }
        else
        {
            count++;
            answer = "Wrong";
        }


        if (count != GameObject.Find("aircraftManager").GetComponent<aircraftManager>().GetAmountOfPlane())
        {
            timerStart = true;
            deactiveButtons();
            panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = planeName;
            panel.transform.GetChild(5).gameObject.GetComponent<Text>().text = answer;
            scoreText.text = "Score: " + score + "/" + count;
        }
        planeSelected = false;

    }
    public int getCount()
    {
        return count;
    }

    public int getScore()
    {
        return score;
    }
    public void resetScore()
    {
        panel.SetActive(false);
        score = 0;
        count = 0;
        scoreText.text = "Score: " + score + "/" + count;
    }

    public void alliedPlane()
    {
        alliedSelected = true;
    }

    public void axisPlane()
    {
        axisSelected = true;
    }
    public void deactiveButtons()
    {
        panel.transform.GetChild(1).gameObject.SetActive(false);
        panel.transform.GetChild(2).gameObject.SetActive(false);
        panel.transform.GetChild(4).gameObject.SetActive(true);
        panel.transform.GetChild(5).gameObject.SetActive(true);
    }
    public void activeButtons()
    {
        panel.transform.GetChild(1).gameObject.SetActive(true);
        panel.transform.GetChild(2).gameObject.SetActive(true);
        panel.transform.GetChild(4).gameObject.SetActive(false);
        panel.transform.GetChild(5).gameObject.SetActive(false);
    }
}