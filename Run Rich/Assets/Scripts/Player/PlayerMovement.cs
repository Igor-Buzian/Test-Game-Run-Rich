using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f; // ���������� �������� ��� �������� ��������
    public float sensitivityMultiplier = 0.1f; // �������� ��� ������� ��������

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
                startPos = currentPos; // ��������� ��������� ������� ��� ���������� �����
            }
        }
    }
}
/*using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // �������� �������� ������
    public float rotationSpeed = 100f; // �������� ��������
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
        // �������������� �������� ������
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // ������� � ������� ����������
        float turnInput = Input.GetAxis("Horizontal"); // A/D ��� ������� �����/������
        float rotation = turnInput * rotationSpeed * Time.deltaTime;

        // �������
        transform.Rotate(0, rotation, 0);
    }
}*/