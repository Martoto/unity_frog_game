using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField]public GameObject attackPrefab; 

    private Attacks att;
    private int cd = 0;     //attack cooldown
    private int cb = 0;     //combo counter

    void Start()
    {
        att = attackPrefab.GetComponent<Attacks>();

        if (!attackPrefab) {
            attackPrefab = new GameObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cd < att.attTime) {
            cd+=1;
        } else if (cd == att.attTime && Input.GetButtonDown("Fire1")) {
            Attack();
        }

    }

    void Attack() {
        GameObject obj = GameObject.Instantiate(attackPrefab, attackPrefab.transform.parent);
        obj.transform.localScale = attackPrefab.transform.localScale;
        obj.SetActive(true);
    }

}
