using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStomp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weak Point!")
        {
            print("Sigma");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Weak Point Boss!")
        {
           if (collision.gameObject.tag == "Weak Point Boss!")
           {
                print("Boss Oof");
                Destroy(collision.gameObject);


            }
                
        }

    }
}
