using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Shop
{
    public enum ShopTag
    {
        //Colours
        Red, Yellow, Blue, Purple, Orange, Green, Brown, White, Cola, Black, Grey, MultiColoured,
        //Primitives
        Sphere, Cube, Torus, Cylinder, Cone,
        //clothes
        Shirt, Cap, Hat, Ear, Muffs, Trousers, Shorts, Sandals, Boots, Shoes, Tie, Bowtie,
        Hoodie, Glasses, Clothes,
        //food
        Ham, Turkey, Sausages, Steak, Potatoes, Mince, Pie, Broccoli, carrots,
        Parsnips, Aubergine, Leeks, Cauliflower, Onion, Sprouts, Drink, Meat, Vegetable, OtherFood,
        //toys
        Bear, Building, Blocks, Shape, Puzzle, Ring, Tower, Simple, Complex, Toy, Game,

        //other
        Crackers, Christmas, Wine, Brandy, Soda, Cans, Bottle, Book, Camera, Alchohol, ChristmasDuck, Egg,

        //Kitchen
        Pots, Toaster, Kettle, Cup, Glass, Mug, Tea, Boiling,

        //Technology
        Recording, Computer, Music, Speaker,


        //toiletTries
        Perfume, Soap, Shampoo, Scented, Clean, Toiletries, Poo,

        //New Stuff
        KitchenStuff, Technology, Bricks, BingBong


    }

  


   /* [CreateAssetMenu()]
    public class ShopObjectRequest : ScriptableObject
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

    }*/


    [CreateAssetMenu()]
    public class ShopObjectRequest : ScriptableObject
    {
        public ShopTag[] positiveTags;
        public ShopTag[] negativeTags;
        public string RequestMessage = "Default Request, Wife.";
        public string ReplyMessage = "Default Reply, Wife.";

   
        public int percentageComparison(ShopObject Item)
        {
            float amountOfTags = positiveTags.Length;
            float tagsMatched = 0;

            foreach (var tag in negativeTags)
            {
                if(checkContains(Item, tag))
                {
                    return 0;
                }
            }

            foreach (var tag in positiveTags)
            {
                if (checkContains(Item, tag)) tagsMatched++;
            }

           
            return Mathf.RoundToInt(100 * (tagsMatched / amountOfTags));

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
