using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMangerEx
{
    public BaseScene QurrentScene{ get { return GameObject.FindObjectOfType<BaseScene>();}  }

    public void LoadScene(Define.Scene type)
    {
        Managers.Clear();
        SceneManager.LoadScene(GetSceneName(type));
    }

    string GetSceneName(Define.Scene type)
    {
        string name = System.Enum.GetName(typeof(Define.Scene), type);
        return name;
    }

    public void Clear()
    {
        //현재 사용중인 씬을 찾아줘 날려준다
        QurrentScene.Clear();
    }
}
