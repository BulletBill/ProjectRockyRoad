using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpriteRenderer))]
public class ShooterLevelScroll : MonoBehaviour
{
    float ActivateLocation;
    Vector3 Speed;

    // Start is called before the first frame update
    void Start()
    {
        float SpriteHalfHeight = GetComponent<SpriteRenderer>().sprite.rect.height / 2.0f;
        ActivateLocation = ShooterCamera._Camera.CameraPosition().y + (ShooterCamera._Camera.CameraSize().y / 2.0f) + SpriteHalfHeight;
        Speed = new Vector3(0.0f, ShooterGameInstance._ShooterGame.ScrollSpeed * -1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Speed;
        if (transform.position.y <= ActivateLocation)
        {
            foreach (MonoBehaviour comp in GetComponents<MonoBehaviour>())
            {
                comp.enabled = true;
            }
        }
        enabled = false;
    }
}
