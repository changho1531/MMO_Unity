using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    //1. 나한테 RigidBody가 있어야한다 ( IsKinematic :off)
    //2. 상대와 나한테 Collider이 있어야한다( IsKinematic :off)
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log($"Collision !{collision.gameObject.name}");
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log($"Trigger !{other.gameObject.name}");
    //}

    void Start()
    {
        
    }

    void Update()
    {
        //Local <-> World <-> Viewport <-> Screen(화면)

        //Debug.Log(Input.mousePosition);  //화면 픽셀 기준
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // 화면 비율

        //레이어를 사용해 원하는 사물만 캐스팅하기
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            //레이어는 비트를 사용
            int mask = (1 << 8); //768 같은 의미;
            //LayerMask layer = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");  //mask랑 같은 기능을 더 직관적으로 한것
            
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                Debug.Log($"Raycast Camera {hit.collider.gameObject.tag}");
                Debug.Log($"Raycast Camera {hit.collider.gameObject.name}");
            }
        }

        ////밑에 버전 간소화
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, 100.0f))
        //    {
        //        Debug.Log($"Raycast Camera {hit.collider.gameObject.name}");    
        //    }
        //}

        // 클릭된 좌표로 카메라에서 레이 포인트를쏴 어떤 오브젝트인지 알아오는것 풀어쓴 버전
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //    Vector3 dir = mousePos - Camera.main.transform.position;  //카메라에서 클릭한 위치로 가는 방향 벡터를 구한다
        //    dir = dir.normalized;  // 방향의 크기를 1로 맞춤

        //레이저 쏘기
        //    Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);
        //    RaycastHit hit;
        //    if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f)) ;
        //    {
        //        Debug.Log($"Raycast Camera {hit.collider.gameObject.name}");
        //    }
        //}
    }
}
