using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int penetrate;
    // Start is called before the first frame update
    public void Init(float damage, int penetrate)
    {
        this.damage = damage;
        this.penetrate = penetrate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
