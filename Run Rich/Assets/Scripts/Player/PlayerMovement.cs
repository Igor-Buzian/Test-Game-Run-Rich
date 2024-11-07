using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f; // Пониженная скорость для плавного поворота
    public float sensitivityMultiplier = 0.1f; // Уменьшен для большей точности

    private Vector3 startPos;
    private Vector3 currentPos;
       Vector3 SpawnTransform;
    private void Start()
    {
        SpawnTransform = transform.position;
    }

    public void BackToFirstPosition()
    {
        Time.timeScale = 1f;
        transform.position = SpawnTransform;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                currentPos = touch.position;
                float deltaX = currentPos.x - startPos.x;
                float rotation = deltaX * rotationSpeed * sensitivityMultiplier * Time.deltaTime;
                transform.Rotate(0, rotation, 0);
                startPos = currentPos; // Обновляем начальную позицию для следующего кадра
            }
        }
    }
}
/*using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Скорость движения вперед
    public float rotationSpeed = 100f; // Скорость поворота
    Vector3 SpawnTransform;
    private void Start()
    {
        SpawnTransform = transform.position;
    }

    public void BackToFirstPosition()
    {
        Time.timeScale = 1f;
        transform.position = SpawnTransform;
    }
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
}*/