using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
            
        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);

        if (player.IsWallDetected())
            stateMachine.ChangeState(player.wallSlide);

        if(xInput != 0)
            player.SetVelocity(player.moveSpeed * xInput * .8f, rb.velocity.y); 
    }
}
