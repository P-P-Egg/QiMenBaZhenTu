using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFunction : MonoBehaviour {
    private void Update()
    {
        test();
    }
    private void test()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider.gameObject.tag=="zhen")
            {
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}
