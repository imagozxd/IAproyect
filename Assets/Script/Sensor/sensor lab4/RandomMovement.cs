using System.Collections;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float movementSpeed = 5f; // Velocidad de movimiento
    public float changeDirectionInterval = 2f; // Intervalo para cambiar de dirección
    public float movementRange = 10f; // Rango de movimiento en el eje XZ
    public float rotationSpeed = 5f; // Velocidad de rotación para seguir la dirección

    private Vector3 targetDirection; // Dirección objetivo para el movimiento

    private void Start()
    {
        // Iniciar movimiento aleatorio
        ChangeDirection();
        StartCoroutine(ChangeDirectionRoutine());
    }

    private void Update()
    {
        // Mover el GameObject en la dirección objetivo
        Move();
    }

    private void Move()
    {
        // Mover en la dirección objetivo
        transform.position += targetDirection * movementSpeed * Time.deltaTime;

        // Rotar suavemente hacia la dirección objetivo
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Verificar si el GameObject ha salido del rango y cambiar la dirección si es necesario
        if (transform.position.x > movementRange || transform.position.x < -movementRange ||
            transform.position.z > movementRange || transform.position.z < -movementRange)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        // Cambiar la dirección a una nueva dirección aleatoria en el eje XZ
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        targetDirection = new Vector3(randomX, 0, randomZ).normalized;
    }

    private IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            // Cambiar la dirección cada intervalo
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
