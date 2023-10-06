using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{



    private class Player
    {
        public static int health;
        public static bool isSeen;

        private void CommitPettyTheft()
        {
            Debug.Log("CommitPettyTheft");

        }
    }


    public virtual void DealDamage()
    { // virtual keyword allows overriding

        Player.health -= 10;
    }

    
}
