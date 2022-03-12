using System;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public int maxCollisionAmount;
    public int currentCollisions;
    private Renderer m_Renderer;
    private bool m_ShouldBlink;
    [Range(0, 10)] public float speed = 1;
    private Color m_StartColor;
    public Color endColor = Color.white;
    private AudioSource[] m_AudioSources;

    private void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        m_StartColor = m_Renderer.material.color;
        m_AudioSources = GetComponents<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (this != null)
        {
            m_AudioSources[0].Play();
        }

        if (!collision.collider.tag.Equals("Can") && !collision.collider.tag.Equals("Ground")) return;
        currentCollisions++;

        if (currentCollisions != maxCollisionAmount) return;
        m_ShouldBlink = true;

        if (this != null)
        {
            m_AudioSources[1].Play();
        }

        //Invoke(nameof(DestroySelf), 2);
    }

    private void DestroySelf()
    {
        m_ShouldBlink = false;
        Destroy(gameObject);
        FindObjectOfType<TriesAmount>().DecrementTries();
        enabled = false;
    }

    private void FixedUpdate()
    {
        if (!(transform.position.y < 0)) return;
        //DestroySelf();
    }

    private void Update()
    {
        if (m_ShouldBlink && this != null)
        {
            m_Renderer.material.color = Color.Lerp(m_StartColor, endColor, Mathf.PingPong(Time.time * speed, 1));
        }
    }
    
}
