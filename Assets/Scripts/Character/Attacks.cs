using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private DamageDealer damage;
    [Range(0, 1000)][SerializeField] public int attTime = 1;  

    // Start is called before the first frame update
    void Start()
    {
        damage = GetComponent<DamageDealer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
