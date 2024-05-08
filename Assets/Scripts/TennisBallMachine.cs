using UnityEngine;

public class TennisBallMachine : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform launchPoint;
    public Transform[] player;
    public bool isShoot;
    private int randomPlayerNum;
    public float ballSpeed = 20f; // Speed of the ball
    

    void Update()
    {
        if (isShoot)
        {
            randomPlayerNum = Random.Range(0, player.Length);
            ShootBall();
            isShoot = false;
        }
    }

    void ShootBall()
    {
        GameObject ball = Instantiate(ballPrefab, launchPoint.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 targetPosition = player[randomPlayerNum].position;
            Vector3 direction = (targetPosition - launchPoint.position).normalized;

            // Add random recoil
            float recoilAmount = 0f; // Adjust this value to change the amount of recoil
            Vector3 recoil = new Vector3(Random.Range(-recoilAmount, recoilAmount), Random.Range(-recoilAmount, recoilAmount), Random.Range(-recoilAmount, recoilAmount));
            direction += recoil;

            rb.velocity = direction * ballSpeed;
        }
        else
        {
            Debug.LogError("Ball prefab does not have a Rigidbody component!");
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            isShoot = true;
            Destroy(collision.collider.gameObject);
            Debug.Log("Ball Hit");
        }
    }
}
