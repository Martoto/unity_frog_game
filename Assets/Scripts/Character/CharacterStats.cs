using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStats : MonoBehaviour
{
    private bool dead = false;      
    public bool Dead {
        get {
            return dead;
        }
    }
    [SerializeField] public int health = 6;
    [SerializeField] public Healthbar hpbar;
    [SerializeField] public bool vulnerable = true;
    [Range(0, 5.0f)][SerializeField] public float invulnerabilityTimeDS = 0.1f;
    private Rigidbody2D body;
    private bool noDmg = false;
    private float noDmgTimer = 0;
   

    [Header("Events")]
	[Space]
    public UnityEvent onDeath;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
        if (onDeath == null) {
            onDeath = new UnityEvent();
        } 
        if (hpbar != null) {
            hpbar.setMaxHealth(health);
        }
    }

    void Update() {
        if (hpbar != null) {
            hpbar.setHealth(health);
        }        
        if (health <= 0) {
            kill();
        } else if (noDmg) {
            GetComponent<SpriteRenderer>().color = Color.red;
        } else {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        //invulnerability period timer
        if (noDmg) {
            noDmgTimer += Time.deltaTime;
            if (noDmgTimer > invulnerabilityTimeDS) {
                noDmgTimer -= invulnerabilityTimeDS;
                noDmg = false;
            }
        }
        
    }

    public void damage(int damage, int kback = 0) {
        if (!dead && !noDmg) {
            health -= damage;
            if (kback > 0f) {
                GetComponent<Rigidbody2D>().velocity = (new Vector2(0f, kback));
            }
            noDmg = true;
        }
    }


    public void kill() {
        if (!dead) {
            health = 0;
            Vector3 scale = transform.localScale;
			scale.y *= -1;
			transform.localScale = scale;
			dead = true;
			GetComponent<Rigidbody2D>().velocity = (new Vector2(0f, 6));
            onDeath.Invoke();
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

      /*private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.GetComponent<Rigidbody2D>() != null) {
                double force = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude*collision.gameObject.GetComponent<Rigidbody2D>().mass;

                if (force > 10.00) {
                    damage((int) force/10 , false);
                }
            }
        }*/
}
