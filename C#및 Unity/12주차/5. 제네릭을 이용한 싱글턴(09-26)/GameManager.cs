using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̱��� ���� �Ŵ��� Ÿ���� ��� �޾Ҵ�.
public class GameManager : SingleTon<GameManager>
{
    public GameObject playerObj;
    public GameObject enemySpawnerObj;
    public int curStageNum;
    public int score;

    // �ڽĿ��� �����ǰ� �Ǳ� ������ �θ��� �Լ��� ȣ������ʴ´�.
    private void Awake()
    {
        // base�� �̿��� �θ��� �Լ��� ���� ȣ�� ����
        base.Awake();
        Debug.Log("���ӸŴ���");
    }
}
