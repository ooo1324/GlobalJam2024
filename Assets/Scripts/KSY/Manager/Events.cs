using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events
{
    public event Action MinusScore;
    public event Action PlusScore;
    public event Action AddEnemyEvent;

    public void MinusScoreInvoke()
    {
        MinusScore?.Invoke();
    }

    public void PlusScoreInvoke()
    {
        PlusScore?.Invoke();
    }

    public void AddEnemyInvoke()
    {
        AddEnemyEvent?.Invoke();
    }

}
