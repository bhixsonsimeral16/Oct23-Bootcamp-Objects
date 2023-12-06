using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Player player;
    float horizontal, vertical;
    Vector2 lookTarget;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        lookTarget = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            player.Shoot();
        }
    }

    private void FixedUpdate()
    {
        player.Move(new Vector2(horizontal, vertical), lookTarget);
    }
}
