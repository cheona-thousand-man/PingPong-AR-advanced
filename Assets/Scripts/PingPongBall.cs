using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongBall : MonoBehaviour
{
    [SerializeField]
    private float serveForce = 3.5f;
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private Transform _userRacket;  // 사용자 라켓 위치를 인스펙터에서 연결
    [SerializeField]
    private Camera _userCamera;
    private bool isServed = false;
    private float fixedYPosition;

    void Start()
    {
        // 초기 Y 위치를 저장해 고정
        fixedYPosition = transform.position.y;
    }

    void Update()
    {
        if (!isServed)
        {
            // 탁구채 앞에 공 위치를 따라가도록 설정
            FollowRacket();
        }

        if (!isServed && Input.GetKeyDown(KeyCode.Z))
        {
            ServeBall();
        }
    }

    void FollowRacket()
    {
        // 탁구채의 X, Z 위치를 따라가되 Y 위치는 고정
        Vector3 forwardDirection = new Vector3(_userCamera.transform.forward.x, 0, _userCamera.transform.forward.z).normalized;
        Vector3 servePosition = _userRacket.position + forwardDirection * 0.1f;

        // Y 위치를 고정하여 servePosition에 설정
        transform.position = new Vector3(servePosition.x, fixedYPosition, servePosition.z);
    }

    void ServeBall()
    {
        _rb.velocity = Vector3.zero;  // 초기 속도 리셋
        
        // 공의 위치에서 월드 원점(0, 0, 0) 방향으로 서브 방향 계산
        Vector3 serveDirection = (Vector3.zero - transform.position).normalized;
        _rb.AddForce(serveDirection * serveForce, ForceMode.Impulse);

        isServed = true;
    }

    void OnTriggerEnter(Collider other)
    {
        // 충돌 시 반사 및 기타 반응 처리
        if (other.gameObject.CompareTag("Racket"))
        {
        // 충돌 시 속도나 방향 조정 가능
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("공이 바닥에 충돌");

            // 공의 속도와 힘을 초기화
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            isServed = false;
        }
        
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Net"))
        {
            Debug.Log("공이 네트에 충돌");

            // 공의 속도와 힘을 초기화
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            isServed = false;
        }
    }
}
