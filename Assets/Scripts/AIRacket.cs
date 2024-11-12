using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacket : MonoBehaviour
{
    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private float power = 3.5f;
    [SerializeField]
    private Transform ball;           // 탁구공의 Transform

    // Update is called once per frame
    void Update()
    { 
        // 거리가 followDistance 이내일 때만 공을 따라감
        if (ball.position.x > 1f && ball.position.y > .78f)
        {
            float targetPositionY = ball.position.y;
            float targetPositionZ = ball.position.z;
            float step = speed * Time.deltaTime;

            // Y와 Z 축 모두 공을 따라 움직임
            transform.position = new Vector3(
                transform.position.x,  // X 축은 고정
                Mathf.MoveTowards(transform.position.y, targetPositionY, step),
                Mathf.MoveTowards(transform.position.z, targetPositionZ, step)
            );
        }
        else
        {
            transform.position = new Vector3(1.35f, 1f, 0);
        }
    }

    // AI 라켓과 공이 충돌할 때 반대 방향으로 힘을 가함
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 공의 속도와 힘을 초기화
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;

            // 공의 위치에서 월드 원점 (0, 0, 0) 방향으로 힘을 가할 벡터 계산
            Vector3 toOriginDirection = (Vector3.zero - collision.transform.position).normalized;

            ballRb.AddForce(toOriginDirection * power, ForceMode.Impulse);
        }
    }
}
