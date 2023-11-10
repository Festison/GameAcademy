using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIEvent : MonoBehaviour
{
    public int power = 10;
    public TMP_InputField chatField;

    public Dictionary<string, Action> cheatDic;
    public List<Action> actionList; 
    public void CheatActive(string key)
    {
        if (cheatDic.ContainsKey(key))
        {
            cheatDic[key]();
        }
        Debug.Log(key);
    }

    
    private void Start()
    {
        TestFoo(() => { Debug.Log("사과농장돌리기"); });
        TestIntFoo((int x) => { Debug.Log("정수형"); });
        chatField.onEndEdit.AddListener(CheatActive);
        cheatDic = new Dictionary<string, Action>();
        cheatDic.Add("overpower", () => { power += 100000; });
        actionList = new List<Action>();
        actionList.Add(() => { power += 1000; });
    }

    public void TestFoo(Action action)
    {
        Debug.Log("시작");
        action();
        Debug.Log("끝");
    }

    public void TestIntFoo(Action<int> action)
    {
        action(5);
    }

}
