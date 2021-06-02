using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Shapes {
    public class GarryAmmoBar : MonoBehaviour
    {
        public Disc AmmoDisc;
        public int Health = 40;


        private void FixedUpdate()
        {
            


            Shapes.DashSpace.FixedCount.Equals(Health);
        }







    }
}