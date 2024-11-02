using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;           // �������� �������� ������
    public float rotationSpeed = 100f;  // �������� ��������

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
}