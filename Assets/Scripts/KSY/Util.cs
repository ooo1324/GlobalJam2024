using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    /// <summary>
    /// ���� ������Ʈ�� T�� ã���ִ� �Լ�, ���� ��� �߰��ؼ� ��ȯ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns>ã�ų�, �߰��� T ��ȯ</returns>
    public static T GetOrAddComponent<T>(GameObject obj) where T : UnityEngine.Component
    {
        T component = obj.GetComponent<T>();

        if (component == null)
            component = obj.AddComponent<T>();

        return component;
    }
}
