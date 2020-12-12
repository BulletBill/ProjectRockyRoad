using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public int MaxHealth;
    public int CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int Amount)
    {
        CurrentHealth -= Amount;
        if (CurrentHealth <= 0)
        {
            Destroyed();
        }
    }

    public void Destroyed()
    {
        GameObject.Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.layer == collision.gameObject.layer)
        {
            return;
        }
    }
}
