using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̱��� ���� �Ŵ��� Ÿ���� ��ӹ޾Ҵ�.
public class SoundManager : SingleTon<SoundManager>
{
    public GameObject soundPrefab;

    public void Play()
    {
        Instantiate(soundPrefab);
    }
}
