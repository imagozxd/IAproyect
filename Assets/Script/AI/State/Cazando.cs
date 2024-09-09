using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cazando : StateWait
{
    void Awake()
    {
        this.LoadComponent();
    }
    public override void LoadComponent()
    {
        stateType = StateType.Cazando;
        base.LoadComponent();
    }
    public override void Enter()
    {
        base.Enter();
        stateNode = StateNode.MoveTo;
        Debug.Log("Cazando Enter ");
    }
    public override void Execute()
    {
        base.Execute();


        switch (stateNode)
        {
            case StateNode.MoveTo:
                base.MoveToPlace();
                float distancia = (transform.position - place.position).magnitude;
                if (distancia < 1)
                {
                    stateNode = StateNode.StartStay;
                }
                break;
            case StateNode.StartStay:
                StartCoroutineWait();
                stateNode = StateNode.Stay;
                break;
            case StateNode.Stay:
                if (!WaitTime)
                {
                    _MachineState.ActiveState(GetRandomStateType());
                    return;
                }
                Debug.Log("Cazando Execute ");
                break;
            case StateNode.Finish:
                break;
            default:
                break;
        }




    }
    public override void Exit()
    {
        base.Exit();
        stateNode = StateNode.MoveTo;
        Debug.Log("Comiendo Exit ");
    }
}
