using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Player player;
    float horizontal, vertical;
    Vector2 lookTarget;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (!GameManager.GetInstance().IsPlaying())
            return;

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        lookTarget = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            player.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            player.UseNuke();
        }
    }

    private void FixedUpdate()
    {
        player.Move(new Vector2(horizontal, vertical), lookTarget);
    }
}
