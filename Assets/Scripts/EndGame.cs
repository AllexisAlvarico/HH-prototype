using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private GameObject hitBox;

    [SerializeField]
    private GameObject endScreen;

    [SerializeField]
    private GameObject aircraftManager;

    [SerializeField]
    private Text endingText;

    [SerializeField]
    private Text scoreText;



    // Update is called once per frame
    void Update()
    {
        // When the number of planes checked matches the total number of planes in the game, end it and show the end panel
        if(hitBox.GetComponent<PlaneSelection>().getCount() == aircraftManager.GetComponent<aircraftManager>().GetAmountOfPlane() && !endScreen.activeSelf)
        {
            endScreen.SetActive(true);
            scoreText.gameObject.SetActive(false);
            endingText.gameObject.SetActive(true);
            endingText.text =  "Final Score: " + hitBox.GetComponent<PlaneSelection>().getScore() + "/" + hitBox.GetComponent<PlaneSelection>().getCount();
        }
    }

    public void ResetGame()
    {
        endScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        endingText.gameObject.SetActive(false);
        hitBox.GetComponent<PlaneSelection>().resetScore();
        switch (aircraftManager.GetComponent<aircraftManager>().amountOfPlane)
        {
            case 6:
                aircraftManager.GetComponent<aircraftManager>().Level(6);
                break;
            case 12:
                aircraftManager.GetComponent<aircraftManager>().Level(12);
                break;
            case 18:
                aircraftManager.GetComponent<aircraftManager>().Level(18);
                break;
            default:
                Debug.Log("Can't find Current Difficulty");
                break;
        }
    }

    public void ChangeDifficulty()
    {
        SceneManager.LoadScene("RadarScene");
    }
}
