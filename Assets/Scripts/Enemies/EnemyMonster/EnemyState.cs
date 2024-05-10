using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Enemy_Monster enemy;
    protected EnemyStateMachine enemyStateMachine;

    public EnemyState(Enemy_Monster enemy, EnemyStateMachine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
    }
}
