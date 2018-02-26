using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{

    Vector3 _destination;
    Vector3 _velocity = Vector3.zero;

    override public void Start()
    {
        //WayPoint 를 가지고 온다.
        _character.ArriveDestination();
        _destination = _character.GetTargetPosition();
        _character.SetAnimationTrigger("move");

    }

    override public void Stop()
    {

    }

    override public void Update()
    {
        
        _destination.y = _character.GetPosition().y;
        Vector3 direction = (_destination - _character.GetPosition()).normalized;
        _velocity = direction * 6.0f;

        Vector3 snapGround = Vector3.zero;
        if (_character.IsGround())
            snapGround = Vector3.down;

        // 목적지와 현재 위치가 일정 거리 이상이면 -> 이동
        float distance = Vector3.Distance(_destination, _character.GetPosition());
        if (0.5f < distance)
        {
            _character.Rotate(direction);
            _character.Move(_velocity * Time.deltaTime + snapGround);

            // 이동중에 플레이어가 있으면 플레이어한데 다가간다.
            
        }
        else
        {

            /*
            // WayPoint에 도착을 하면, 다음 웨이 포인트 목적지 변경 
            WayPoint wayPoint = _character.GetWayPoint(_wayPointIndex);
            _wayPoint++;

            _destination = wayPoint.GetPosition();
            */
            _character.ArriveDestination();
            _destination = _character.GetTargetPosition();

        }
    }

    override public void UpdateInput()
    {

    }
}
