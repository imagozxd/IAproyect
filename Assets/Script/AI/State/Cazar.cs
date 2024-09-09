using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cazar : StateMove
{


    // Start is called before the first frame update
    void Awake()
    {
        this.LoadComponent();
    }
    public override void LoadComponent()
    {
        //stateType = StateType.Comer;
        base.LoadComponent();
    }
    public override void Enter()
    {

        Debug.Log("Cazar Enter ");
    }
    public override void Execute()
    {
        // Calcula la fuerza de dirección
        Vector3 steeringForce = _SteeringBehavior.Arrive(place);

        // Aplica la fuerza a la velocidad
        _SteeringBehavior.ClampMagnitude(steeringForce);

        // Actualiza la posición del objeto
        _SteeringBehavior.UpdatePosition();
        Debug.Log("Cazar Execute ");
    }
    public override void Exit()
    {
        Debug.Log("Cazar Exit ");
    }
    // Update is called once per frame

}
