using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Shop
{
    public enum ShopTag
    {
        Red, Yellow, Blue, Purple, Orange, Green,
        Sphere, Cube, Torus, Cylinder, Cone,



    }

    [CreateAssetMenu()]
    public class ShopObject : ScriptableObject
    {
        public string Name;    //Not used in code just for Identification.  
        public ShopTag[] Tags; //for comparison to shop requests.
    }

    [System.Serializable]
    public class ShopObjectRequest
    {
        public ShopObject toCompare;
        public bool exactComparison(ShopObject Item)
        {
            foreach (var tag in toCompare.Tags)
            {
                if (!checkContains(Item, tag)) return false;
            }

            return true;
        }
        public int percentageComparison(ShopObject Item)
        {
            float amountOfTags = toCompare.Tags.Length;
            float tagsMatched = 0;

            foreach (var tag in toCompare.Tags)
            {
                if (checkContains(Item, tag)) tagsMatched++;
            }

            return Mathf.RoundToInt(100*(tagsMatched / amountOfTags));

        }                           
        private bool checkContains(ShopObject Item, ShopTag testTag)
        {

            foreach (var tag in Item.Tags)
            {
                if (tag == testTag) return true;
            }

            return false;
        }

    }


  

}
