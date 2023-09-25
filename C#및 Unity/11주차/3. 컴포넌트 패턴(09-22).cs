using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 컴포넌트 패턴 : 빈 컨테이너에 필요할 떄마다 원하는 기능을 갖다 붙여 포함시키는 방식 예) 부품
// 특징 : 기능을 나누어 각자 독립적인 클래스를 만들어 두고, 만들어 둔 것을 부품 붙이듯이 갖다 붙일 수 있다.
// 장점 : 컴포넌트들끼리 독립적이며 결합도가 낮다. 컴포넌트만 수정하면 되서 유지보수시 편하다.
public class DetectiveComponent : MonoBehaviour
{
    [Header("레이어 마스크")]
    [SerializeField] LayerMask targetLayerMask;

    [Space(10f)]
    [Range(0, 15)]
    [Header("레이 캐스트 범위")]
    [SerializeField] float radius;
    [Range(0, 15)]
    [SerializeField] float maxDistance;

    [Space(10f)]
    [Header("감지 상태")]
    [SerializeField]
    bool isRangeDetection;
    [SerializeField]
    bool isRayDetection;

    [Space(10f)]
    [Header("감지된 콜라이더")]
    [SerializeField]
    Collider[] cols;

    public Vector3 LastDetectivePos
    {
        get;
        private set;
    }

    public bool IsDection
    {
        get
        {
            return isRayDetection && isRangeDetection;
        }
    }

    bool CheckInLayerMask(int layerIndex)
    {
        return (targetLayerMask & (1 << layerIndex)) != 0;
    }

    void Update()
    {
        // 원하는 시점에서 특정 콜라이더 들을 검출 할 수 있다.
        cols = Physics.OverlapSphere(transform.position, radius, targetLayerMask);
        isRangeDetection = (bool)(cols.Length > 0);

        if (isRangeDetection)
        {
            // 레이캐스트에 부딪힌 물체
            RaycastHit hit;
            Vector3 direction = ((cols[0].transform.position) - transform.position).normalized;
            Debug.DrawLine(transform.position, transform.position + (direction * maxDistance), Color.blue);

            if (Physics.Raycast(transform.position, direction, out hit, maxDistance))
            {
                // 부딪힌 물체의 레이어 마스크를 가져온다.
                isRayDetection = CheckInLayerMask(hit.collider.gameObject.layer);
                if (isRayDetection)
                {
                    LastDetectivePos = hit.transform.position;
                    Debug.DrawLine(transform.position, transform.position + (direction * maxDistance), Color.red);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
