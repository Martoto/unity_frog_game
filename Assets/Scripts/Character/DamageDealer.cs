using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DamageDealer : MonoBehaviour
{
    [Range(0, 100)][SerializeField] int damage = 1;

    public bool damagesPlayer = true;
    [SerializeField][Range(0, 100)] int knockback = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<CharacterStats>() != null) {
            if (damagesPlayer || other.gameObject.layer != 8){
                Debug.Log(other.gameObject.layer);
                other.gameObject.GetComponent<CharacterStats>().damage(damage, knockback);
            }
        }
    }
}
