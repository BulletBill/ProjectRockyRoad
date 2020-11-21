using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBulletMover : MonoBehaviour
{
    public Vector3 Velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ShooterGameInstance.IsPaused()) { return; }

        transform.position += (Velocity * Time.deltaTime);

        if (false == ShooterCamera.SpriteOnCamera(GetComponent<SpriteRenderer>()))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
