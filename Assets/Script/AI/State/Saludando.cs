using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saludando : StateWait
{
    void Awake()
    {
        this.LoadComponent();
    }
    public override void LoadComponent()
    {
        stateType = StateType.Saludando;
        base.LoadComponent();
    }
    public override void Enter()
    {
        base.Enter();
        stateNode = StateNode.MoveTo;
        Debug.Log("Saludando Enter ");
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
                Debug.Log("Saludando Execute ");
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
