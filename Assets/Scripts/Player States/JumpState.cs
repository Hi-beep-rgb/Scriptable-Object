//This is a derived class of State
//This means it inherits fields and methods from State.cs


using UnityEngine;
using UnityEngine.InputSystem;

public class JumpState : State
{
    float rotationSpeed;
    float jumpSpeed = 10;
    
    public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        if(player.jumpAction.IsPressed())
        {
            player.rb.linearVelocityY = jumpSpeed;
        }

        player.anim.Play("JumpAnim");
        Debug.Log("entering jumping state");
    }

    public override void Exit()
    {
        //exit the jump state
    }

    public override void Update()
    {
        ReadInput();

        if (player.interactAction.IsPressed())
        {
            sm.ChangeState(sm.idleState);
        }

        float x = player.moveAction.ReadValue<Vector2>().x;

        if (x > 0.1f || x < -0.1f)
        {
            sm.ChangeState(sm.runState);
        }

        UIscript.ui.DrawText("*** This is the jumping state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move State");
        UIscript.ui.DrawText("E = Idle State");


    }

    public override void FixedUpdate()
    {
        //Fixed Update 
    }
}