using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;           // Скорость движения вперед
    public float rotationSpeed = 100f;  // Скорость поворота

    void Update()
    {
        // Автоматическое движение вперед
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Поворот с помощью клавиатуры
        float turnInput = Input.GetAxis("Horizontal"); // A/D или стрелки влево/вправо
        float rotation = turnInput * rotationSpeed * Time.deltaTime;

        // Поворот
        transform.Rotate(0, rotation, 0);
    }
}