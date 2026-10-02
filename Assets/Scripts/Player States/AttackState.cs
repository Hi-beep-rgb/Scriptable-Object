//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;

public class AttackState : State
{
    public AttackState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        player.anim.Play("Attack1Anim");
    }

    public override void Exit()
    {
        // this method is called when the state has finished
        Debug.Log("exiting attack state");
    }

    public override void Update()
    {
        ReadInput();
    }
}
