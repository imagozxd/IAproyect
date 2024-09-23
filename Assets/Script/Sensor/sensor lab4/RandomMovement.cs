using System.Collections;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float movementSpeed = 5f; // Velocidad de movimiento
    public float changeDirectionInterval = 2f; // Intervalo para cambiar de direcci�n
    public float movementRange = 10f; // Rango de movimiento en el eje XZ
    public float rotationSpeed = 5f; // Velocidad de rotaci�n para seguir la direcci�n

    private Vector3 targetDirection; // Direcci�n objetivo para el movimiento

    private void Start()
    {
        // Iniciar movimiento aleatorio
        ChangeDirection();
        StartCoroutine(ChangeDirectionRoutine());
    }

    private void Update()
    {
        // Mover el GameObject en la direcci�n objetivo
        Move();
    }

    private void Move()
    {
        // Mover en la direcci�n objetivo
        transform.position += targetDirection * movementSpeed * Time.deltaTime;

        // Rotar suavemente hacia la direcci�n objetivo
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Verificar si el GameObject ha salido del rango y cambiar la direcci�n si es necesario
        if (transform.position.x > movementRange || transform.position.x < -movementRange ||
            transform.position.z > movementRange || transform.position.z < -movementRange)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        // Cambiar la direcci�n a una nueva direcci�n aleatoria en el eje XZ
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        targetDirection = new Vector3(randomX, 0, randomZ).normalized;
    }

    private IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            // Cambiar la direcci�n cada intervalo
            ChangeDirection();
            yield return new WaitForSeconds(changeDirectionInterval);
        }
    }

    public void MoveToTarget(Transform target)
    {
        float moveSpeed = 5f; // Ajusta la velocidad de movimiento
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

}
