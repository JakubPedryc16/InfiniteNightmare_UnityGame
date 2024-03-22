using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnaffectedState : State
{
    private Enemy enemy;
    public UnaffectedState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void RefreshState()
    {

    }
    public void UpdateState()
    {

    }
}
