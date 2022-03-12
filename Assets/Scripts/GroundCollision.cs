using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundCollision : MonoBehaviour
{

    private List<Collider> m_AlreadyRegisteredColliders;
    private int m_CanAmount;
    private CanScore m_CanScore;

    private void Start()
    {
        m_CanAmount = FindObjectOfType<CanManager>().canAmount;
        m_CanScore = FindObjectOfType<CanScore>();
        m_AlreadyRegisteredColliders = new List<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.tag.Equals("Can") || m_AlreadyRegisteredColliders.Contains(collision.collider)) return;
        m_CanScore.IncrementCanScore();
        m_AlreadyRegisteredColliders.Add(collision.collider);

        if (m_CanScore.currentCanScore != m_CanAmount) return;
        m_CanScore.DisplayWinMessage();
        Invoke(nameof(RestartScene), 5f);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
