using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;

    void Update()
    {
        // �������������� �������� ������
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // ������� � ������� ������� ���������� (��� ��������� ��������)
        float rotationX = Input.acceleration.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationX);
    }
}