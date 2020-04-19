using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public float Strength;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
    {
        Collider2D[] overlapping = Physics2D.OverlapCircleAll((Vector2)transform.position, Strength);
        List<Rigidbody2D> bodies = overlapping.Select(col => col.gameObject.GetComponent<Rigidbody2D>()).Where(rb => rb != null).ToList();

        print("exploded!");

        foreach (Rigidbody2D body in bodies)
        {
            print("sent body!");

            Vector3 dir = (body.transform.position - transform.position).normalized;

            float distance = (body.transform.position - transform.position).magnitude;

            body.AddForce(dir * Strength *  (1 / distance), ForceMode2D.Impulse);
        }
    }
}
