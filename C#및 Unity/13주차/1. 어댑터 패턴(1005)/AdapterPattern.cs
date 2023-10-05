using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� ���� : �� Ŭ������ �������̽��� Ŭ���̾�Ʈ���� ����ϰ��� �ϴ� �ٸ� �������̽��� ��ȯ�Ѵ�.
// �������̽� ȣȯ�� ���� ������ ���� �� �� ���� Ŭ�������� �����ؼ� �� ���� �ִ�.
public class AdapterPattern : MonoBehaviour, IHitable
{
    Wall wall;

    private void Start()
    {
        wall = GetComponent<Wall>();
    }

    public void Hit(IAttackable attackable)
    {
        wall.WallDestory();
    }
}
