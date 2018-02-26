using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    Vector3 _velocity = Vector3.zero;

    override public void Start()
    {
        Vector3 destination = _character.GetTargetPosition();

        float distance = Vector3.Distance(destination, _character.GetPosition());
        _character.SetAnimationTrigger("move");
    }

    override public void Stop()
    {
    }

    override public void Update()
    {
        Vector3 destination = _character.GetTargetPosition();
        destination.y = _character.GetPosition().y;
        Vector3 direction = (destination - _character.GetPosition()).normalized;
        _velocity = direction * 6.0f;

        Vector3 snapGround = Vector3.zero;
        if (_character.IsGround())
            snapGround = Vector3.down;

        // 목적지와 현재 위치가 일정 거리 이상이면 -> 이동
        float distance = Vector3.Distance(destination, _character.GetPosition());
        if (1.5f < distance)
        {
            _character.Rotate(direction);
            _character.Move(_velocity * Time.deltaTime + snapGround);
        }
        else
        {
            _character.ChangeState(Player.eState.ATTACK);
        }
    }

    override public void UpdateInput()
    {
        //_destination = _character.GetTargetPosition();
    }
}
