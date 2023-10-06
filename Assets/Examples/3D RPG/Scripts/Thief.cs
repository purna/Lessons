using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Enemy
{


    public class Player
    {
        private int health; // field
        public int Health  // property
        {
            get { return health; }
            set { health = value; }
        }

        public static bool isSeen;

        /*
        public void CommitPettyTheft()
        {
            Debug.Log("CommitPettyTheft");

        }
        */
    }


    public override void DealDamage() // can override virtual methods from parent class
    {
        Player player = new Player();
        player.Health -= 2;
        //player.CommitPettyTheft();
    }


    private void Update()
    {
        if (Player.isSeen)
        {
            DealDamage();
        }
    }
}