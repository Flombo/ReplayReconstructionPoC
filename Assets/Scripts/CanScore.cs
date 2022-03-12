using UnityEngine;
using UnityEngine.UI;

public class CanScore : MonoBehaviour
{
    public Text canScore;
    public int currentCanScore = 0;
    public Canvas scoreCanvas;
    public GameObject winCanvas;
    [HideInInspector]
    public bool isGameWon;

    public void IncrementCanScore()
    {
        currentCanScore++;
        canScore.text = currentCanScore.ToString();
    }

    public void DisplayWinMessage()
    {
        isGameWon = true;
        if (!FindObjectOfType<TriesAmount>().isGameLost)
        {
            scoreCanvas.enabled = false;
            FindObjectOfType<AudioManager>().Play("WinSound");
            winCanvas.SetActive(true);
        }
        else
        {
            isGameWon = false;
        }
    }
    
}
