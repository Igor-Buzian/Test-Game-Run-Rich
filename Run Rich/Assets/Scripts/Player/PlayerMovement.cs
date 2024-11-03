using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f; // ѕониженна€ скорость дл€ плавного поворота
    public float sensitivityMultiplier = 0.1f; // ”меньшен дл€ большей точности

    private Vector3 startPos;
    private Vector3 currentPos;

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
                startPos = currentPos; // ќбновл€ем начальную позицию дл€ следующего кадра
            }
        }
    }
}