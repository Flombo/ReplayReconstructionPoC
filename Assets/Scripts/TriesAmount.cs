using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriesAmount : MonoBehaviour
{
    private int m_MaxTries;
    public Text triesAmountText;
    public Canvas scoreCanvas;
    public GameObject loseCanvas;
    [HideInInspector]
    public bool isGameLost;

    private void Start()
    {
        m_MaxTries = FindObjectOfType<BallCrateManager>().ballAmount;
        triesAmountText.text = m_MaxTries.ToString();
    }

    public void DecrementTries()
    {
        m_MaxTries--;
        triesAmountText.text = m_MaxTries.ToString();
        if (m_MaxTries == 0)
        {
            if (FindObjectOfType<CanScore>().isGameWon) return;
            isGameLost = true;
            FindObjectOfType<AudioManager>().Play("LoseSound");
            scoreCanvas.enabled = false;
            loseCanvas.SetActive(true);
            Invoke(nameof(ReloadScene), 6f);
        }
        else
        {
            isGameLost = false;
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
