using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightDesignPattern
{

    public class TreeFactory 
    {
        private static Dictionary<string,ITree> trees = new Dictionary<string, ITree>();

        public static ITree GetTree(TreeType treeType,string treeName,int treeAge,string color,string model)
        {
            if(trees.TryGetValue(treeName,out ITree _tree))
            {
                return _tree;
            }

            GameObject treePrefab = null;

            switch(treeType)
            {
                case TreeType.KavakAgaci:
                    treePrefab = Resources.Load<GameObject>("Prefab/Tree");
                break;
                default:
                break;
            }

           
            GameObject tree = GameObject.Instantiate(treePrefab);
            
            ITree treeScript =tree.GetComponent<KavakAgaci>(); 
            
            treeScript.Age = treeAge;
            treeScript.Color = color;
            treeScript.Model = model;

            trees[treeName] = treeScript;
            
            return trees[treeName];
        }
    }

}
