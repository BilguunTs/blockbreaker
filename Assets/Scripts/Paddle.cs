using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 0f;
    [SerializeField] float maxX = 16f;
    [SerializeField] float ScreenWithInUnit = 16f;
    Vector2 paddlePos = new Vector2(0,0.29f);
 

    private void HandleMovePaddle()
    {
        float mousepositionX = Input.mousePosition.x / Screen.width * ScreenWithInUnit;
        paddlePos.x = Mathf.Clamp(mousepositionX, minX, maxX);
        transform.position = paddlePos;
    }

    void Update()
    {
        this.HandleMovePaddle();
    }
}
