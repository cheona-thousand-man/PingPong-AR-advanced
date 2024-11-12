using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRacket : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float power = 3.5f;
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private Camera _userCamera;
    
    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        // 카메라의 오른쪽 방향과 위쪽 방향을 기준으로 이동 방향 계산
        Vector3 movement =  _userCamera.transform.right * (moveHorizontal * speed) 
                         + _userCamera.transform.up * (moveVertical * speed);
        
        // Rigidbody 이동
        _rb.MovePosition(_rb.position + movement * Time.deltaTime);
    }

    // 공과 충돌할 때 반대 방향으로 힘을 가함
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
            if (ballRb != null)
            {
                // 공의 위치에서 월드 원점 (0, 0, 0) 방향으로 힘을 가할 벡터 계산
                Vector3 toOriginDirection = (Vector3.zero - collision.transform.position).normalized;

                ballRb.AddForce(toOriginDirection * power, ForceMode.Impulse);
            }
        }
    }
}
