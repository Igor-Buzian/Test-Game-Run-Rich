using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;

    void Update()
    {
        // Автоматическое движение вперед
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Поворот с помощью наклона устройства (для мобильных платформ)
        float rotationX = Input.acceleration.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationX);
    }
}