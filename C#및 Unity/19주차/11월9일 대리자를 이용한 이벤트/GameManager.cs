using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public delegate void BtnAction(Btn sender, BtnEventArgs args);

public class BtnEventArgs : EventArgs
{
    public int count;
    public float size;
    public Vector3 pos;

    public BtnEventArgs(int count, float size, Vector3 pos)
    {
        this.count = count;
        this.size = size;
        this.pos = pos;
    }
}

public class Btn
{
    public string name;
    public int value;

    // event Ű���带 �߰������ν� ��������Ʈ�� ����� �̺�Ʈ�� �ƴ� �������� �۵��ϴ� ���� �����ִ� ���Դϴ�.
    public event BtnAction onClick;

    public event Action<Btn, BtnEventArgs> action;

    public void Click()
    {
        onClick(this,new BtnEventArgs(0,1,new Vector3(0,1,1)));       
    }
}

public class GameManager : MonoBehaviour
{

    Btn btnA = new Btn();
    void Start()
    {
      
        btnA.name = "������ư";
        btnA.value = 100;
        btnA.onClick += (Btn btn,BtnEventArgs info) => { Debug.Log(info.size+"��ư ������"); };
        btnA.onClick += (Btn btn, BtnEventArgs info) => { Debug.Log(btn.name); };
        
        btnA.Click();
 
    }
 
}
