using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDuck : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Convert the mouse position on the screen to world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Raycast from where the mousePosition is to check what the mouse is ontop of
            RaycastHit2D rayHit = Physics2D.Raycast(mousePosition, Vector2.zero);
            // If the raycast hit something, then check if it hit the game object with the Duck tag
            if (rayHit.collider != null)
            {
                if (rayHit.collider.tag == "Duck")
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
