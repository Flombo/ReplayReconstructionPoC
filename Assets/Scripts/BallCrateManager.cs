using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallCrateManager : MonoBehaviour
{
    [Range(1, 30)]
    public int ballAmount;
    public GameObject ballPrefab;
    private List<GameObject> balls;
    private float initialBounciness;

    private void Start()
    {

        balls = new List<GameObject>();

        var localScale = transform.localScale;
        var ballCrateHeight = localScale.y;
        var ballCrateDepth = localScale.x;
        
        for (var i = 0; i < ballAmount; i++)
        {
            var currentPosition = transform.position;

            var ballX = Random.Range(currentPosition.x - ballCrateDepth / 2, currentPosition.x + ballCrateDepth / 2);
            var ballY = Random.Range(currentPosition.y, currentPosition.y + ballCrateHeight / 2);
            const float ballZ = 0.05f;

            var ballPosition = new Vector3(
                ballX,
                ballY,
                ballZ
                );
            
            var ball = Instantiate(
                ballPrefab,
                ballPosition,
                Quaternion.identity
            );

            initialBounciness = ball.GetComponent<SphereCollider>().material.bounciness;
            ball.GetComponent<SphereCollider>().material.bounciness = 0f;
            
            balls.Add(ball);
        }
        
        balls.ForEach(ball =>
        {
            ball.GetComponent<SphereCollider>().material.bounciness = initialBounciness;
        });
    }

}
