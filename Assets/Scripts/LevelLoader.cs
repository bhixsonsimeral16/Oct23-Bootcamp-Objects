using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // Player object
        Player myPlayer = new Player();

        // Enemy objects
        Enemy meleeEnemy = new Enemy();
        Enemy rangedEnemy = new Enemy();

        // Weapon objects
        Weapon gun1 = new Weapon("Pistol", 10f);
        Weapon machineGun1 = new Weapon("Machine Gun", 2f);
        Weapon meleeWeapon1 = new Weapon("Sword", 20f);

        myPlayer.weapon = gun1;
        rangedEnemy.weapon = machineGun1;
        meleeEnemy.weapon = meleeWeapon1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
