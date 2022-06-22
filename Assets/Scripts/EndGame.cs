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
        switch (aircraftManager.GetComponent<aircraftManager>().currentDifficulty)
        {
            case "Easy":
                aircraftManager.GetComponent<aircraftManager>().EasyLevel();
                break;
            case "Medium":
                aircraftManager.GetComponent<aircraftManager>().MediumLevel();
                break;
            case "Hard":
                aircraftManager.GetComponent<aircraftManager>().HardLevel();
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
