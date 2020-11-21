using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ShooterPlayerWeapons : MonoBehaviour
{

    public bool ActiveWeapon;
    public float ShotDelay;
    float ShotTimer;

    public GameObject Bullet;
    public List<Vector2> ShotVelocities;
    public List<Vector2> ShotOffsets;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        if (ShooterGameInstance.IsPaused()) { return; }

        if (ShotTimer > 0.0f)
        {
            ShotTimer -= Time.deltaTime;
            return;
        }

		if (!ActiveWeapon) { return; }

		if (Input.GetAxisRaw("Fire") > 0.0f)
        {
            if (Bullet == null) return;
            if (ShotVelocities.Count <= 0.0f) return;
            if (ShotOffsets.Count <= 0.0f) return;
            if (ShotDelay <= 0.0f) return;

            int i = 0;
            foreach (Vector2 pos in ShotOffsets)
            {
                GameObject newBullet = Instantiate(Bullet, new Vector3(pos.x + transform.position.x, pos.y + transform.position.y, 0.0f), Quaternion.identity);
                newBullet.GetComponent<ShooterBulletMover>().Velocity = ShotVelocities[i % ShotVelocities.Count];
                i++;
            }

            ShotTimer = ShotDelay;
        }
    }
}
