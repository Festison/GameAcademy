using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������Ʈ ���� : �� �����̳ʿ� �ʿ��� ������ ���ϴ� ����� ���� �ٿ� ���Խ�Ű�� ��� ��) ��ǰ
// Ư¡ : ����� ������ ���� �������� Ŭ������ ����� �ΰ�, ����� �� ���� ��ǰ ���̵��� ���� ���� �� �ִ�.
// ���� : ������Ʈ�鳢�� �������̸� ���յ��� ����. ������Ʈ�� �����ϸ� �Ǽ� ���������� ���ϴ�.
public class DetectiveComponent : MonoBehaviour
{
    [Header("���̾� ����ũ")]
    [SerializeField] LayerMask targetLayerMask;

    [Space(10f)]
    [Range(0, 15)]
    [Header("���� ĳ��Ʈ ����")]
    [SerializeField] float radius;
    [Range(0, 15)]
    [SerializeField] float maxDistance;

    [Space(10f)]
    [Header("���� ����")]
    [SerializeField]
    bool isRangeDetection;
    [SerializeField]
    bool isRayDetection;

    [Space(10f)]
    [Header("������ �ݶ��̴�")]
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
        // ���ϴ� �������� Ư�� �ݶ��̴� ���� ���� �� �� �ִ�.
        cols = Physics.OverlapSphere(transform.position, radius, targetLayerMask);
        isRangeDetection = (bool)(cols.Length > 0);

        if (isRangeDetection)
        {
            // ����ĳ��Ʈ�� �ε��� ��ü
            RaycastHit hit;
            Vector3 direction = ((cols[0].transform.position) - transform.position).normalized;
            Debug.DrawLine(transform.position, transform.position + (direction * maxDistance), Color.blue);

            if (Physics.Raycast(transform.position, direction, out hit, maxDistance))
            {
                // �ε��� ��ü�� ���̾� ����ũ�� �����´�.
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
