using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Shop;


[CustomEditor(typeof(ShopObjectReference))]
public class ShopReference_Editor : Editor
{

    public enum Mode {New, Copy};
    public Mode mode = Mode.Copy;
    public readonly string Path = Application.streamingAssetsPath;


    public override void OnInspectorGUI()
    {
        Debug.Log(Path);


        ShopObjectReference t = (ShopObjectReference)target;

        if (t.shopObject)
        {

            if (GUILayout.Button("Clear Shop Object"))
            {
                t.shopObject = null;

            }

            GUILayout.Label("Shop Object: " + t.shopObject.name);

            string tags = "";
            for (int i = 0; i < t.shopObject.Tags.Length-1; i++)
            {
                tags += t.shopObject.Tags[i] + ", ";
            }
            tags += tags += t.shopObject.Tags[t.shopObject.Tags.Length - 1] + ".";

            GUILayout.Label("Tags: " + tags);


        }
        else
        {

            mode = (Mode)EditorGUILayout.EnumPopup("Create: ", mode);

            switch (mode)
            {
                case Mode.New:
                    EditorGUILayout.LabelField("New Tags");

                    t._editorTagLength = EditorGUILayout.IntField(t._editorTagLength, "Number of Tags");

                    t._toAdd = refactorTags(t._toAdd, t._editorTagLength); 

                    for (int i = 0; i < t._editorTagLength; i++)
                    {
                        t._toAdd[i] = (ShopTag)EditorGUILayout.EnumPopup("Tag "+i+": ", t._toAdd[i]);

                        //("Tag "+i+": ", t._toAdd);

                    }

                    if(t._toAdd.Length > 0)
                    {

                        if (GUILayout.Button("Create"))
                        {
                            ShopObject newShopObject = new ShopObject();
                            newShopObject.Tags = t._toAdd;
                            newShopObject.name = t.gameObject.name;
                            newShopObject.Name = t.gameObject.name;
                            AssetDatabase.CreateAsset(newShopObject, "Assets/ShopTags/"+newShopObject.name+".asset");
                            t.shopObject = newShopObject;
                        }

                    }


                    //    op = (OPTIONS)EditorGUILayout.EnumPopup("Primitive to create:", op);



                    break;
                case Mode.Copy:

                    t.shopObject = (ShopObject)EditorGUILayout.ObjectField("Label:", t.shopObject, typeof(ShopObject), true);
                    break;
                default:
                    break;
            }






            serializedObject.ApplyModifiedProperties();

            //shopObj, new GUIContent("Shop Object"));


            //AssetDatabase.CreateAsset()

        }


        ShopTag[] refactorTags(ShopTag[] current, int length)
        {

            ShopTag[] newTags  = new ShopTag[length];
            if(current.Length < length)
            {
                for (int i = 0; i < current.Length; i++)
                {
                    newTags[i] = current[i];
                }

                for (int i = current.Length; i < length; i++)
                {
                    newTags[i] = ShopTag.Aubergine;
                }
            }
            if(current.Length > length)
            {
                for (int i = 0; i < length; i++)
                {
                    newTags[i] = current[i];
                }    
            }
            if(current.Length == length)
            {
                newTags = current;
            }

            return newTags;

        }


        //base.OnInspectorGUI();
    }


}
