using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_script : MonoBehaviour
{
    public int speed = 5;
    public int speedRotation = 3;
    public int jumpSpeed = 50;

    MovementParticleEmitter MPE;
    // Start is called before the first frame update
    void Start()
    {
        MPE = GetComponent<MovementParticleEmitter>();
    }

    // Возвращет 1 если движение было, 0 в противном случае
    bool MoveAxis(string name, Vector3 dirMove, bool movement)
    {
        float move = Input.GetAxis(name);
        movement = movement | (move != 0);
        if (move > 0)
            transform.Translate(dirMove * 6.0f * Time.deltaTime);
        if (move < 0)
            transform.Translate(dirMove * -6.0f * Time.deltaTime);
        return movement;
    }

    // Update is called once per frame
    void Update()
    {
        bool movement = false;
        movement = MoveAxis("Vertical", transform.forward, movement);
        movement = MoveAxis("Horizontal", transform.right, movement);
        movement = MoveAxis("Jump", transform.up, movement);
        MPE.Switch(movement);
        print(movement);
    }
}
