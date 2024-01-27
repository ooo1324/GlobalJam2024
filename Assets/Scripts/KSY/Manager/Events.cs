using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events
{
    public event Action MinusEnemyEvent;
    public event Action AddEnemyEvent;

    public void MinusEnemyInvoke()
    {
        MinusEnemyEvent?.Invoke();
    }

    public void AddEnemyInvoke()
    {
        AddEnemyEvent?.Invoke();
    }
}
