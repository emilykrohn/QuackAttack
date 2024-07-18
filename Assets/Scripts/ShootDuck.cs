using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDuck : MonoBehaviour
{
    [SerializeField] int rotationAmount;
    [SerializeField] float rotationDuration = 1.0f;
    Score score;
    DuckMovement movement;

    void Start()
    {
        score = FindObjectOfType<Score>();
        movement = GetComponent<DuckMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Convert the mouse position on the screen to world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Raycast from where the mousePosition is to check what the mouse is ontop of
            RaycastHit2D rayHit = Physics2D.Raycast(mousePosition, Vector2.zero);
            // If the raycast hit something, then check if it hit the game object with the Duck tag
            if (rayHit.collider != null && rayHit.collider.CompareTag("Duck"))
            {
                ShootDuck clickedDuck = rayHit.collider.GetComponent<ShootDuck>();
                if (clickedDuck != null)
                {
                    clickedDuck.HandleClick();
                }
            }
        }
    }

    void HandleClick()
    {
        score.incrementScore();
        movement.StopMovement();
        StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        float elapsedTime = 0;
        while (elapsedTime < rotationDuration)
        {
            float angle = rotationAmount * (elapsedTime / rotationDuration);
            gameObject.transform.rotation = Quaternion.Euler(0, angle, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        gameObject.transform.rotation = Quaternion.Euler(0, 0, rotationAmount);
        Destroy(gameObject);
    }
}
