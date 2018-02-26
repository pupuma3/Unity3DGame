using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    override public void Start()
    {
        _character.SetAnimationTrigger("idle");
    }

    override public void Stop()
    {
    }

    override public void Update()
    {
        // 늑대 일때, 일정 시간이 지나면 -> 순찰 상태로
        
    }

    override public void UpdateInput()
    {
        
        _character.ChangeState(Player.eState.MOVE);
    }
}
