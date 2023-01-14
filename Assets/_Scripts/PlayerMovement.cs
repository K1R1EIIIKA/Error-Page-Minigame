using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 movementBase = new(4.5f, 2.2f);
    public Transform hand;
        
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Move(new Vector2(-1, 1));
            Rotate(1);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Move(new Vector2(1, 1));
            Rotate(0);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(new Vector2(-1, -1));
            Rotate(1);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(new Vector2(1, -1));
            Rotate(0);
        }
    }

    // Движение корзинки по кнопкам Q A E D
    private void Move(Vector2 movement)
    {
        transform.position = new Vector3(movementBase.x * movement.x, movementBase.y * movement.y - 1.5f);
    }

    // Поворот персонажа по вертикали
    private void Rotate(float axis)
    {
        hand.rotation = Quaternion.Euler(0, 180*axis, 0);
    }
}
