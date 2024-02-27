using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 5f;

    void Update()
    {
        // Lấy góc quay hiện tại
        Quaternion currentRotation = transform.rotation;

        // Tính toán góc quay mới
        float angle = rotationSpeed * Time.deltaTime;
        Quaternion newRotation = Quaternion.Euler(0, angle, 0) * currentRotation;

        // Áp dụng góc quay mới vào transform
        transform.rotation = newRotation;
    }
}
