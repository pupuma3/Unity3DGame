using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    override public void Init()
    {
        base.Init();
        _characterType = eCharacterType.MONSTER;
    }

    protected override void InitState()
    {
        base.InitState();

        State idleState = new WargIdleState();
        idleState.Init(this);
        _stateList[eState.IDLE] = idleState;
    }

    public List<WayPoint> _wayPointList;
    int _wayPointIndex = 0;

    override public void ArriveDestination()
    {
        WayPoint wayPoint = _wayPointList[_wayPointIndex];
        _wayPointIndex = (_wayPointIndex + 1) % _wayPointList.Count;

        _targetPosition = wayPoint.GetPosition();
    }
}
