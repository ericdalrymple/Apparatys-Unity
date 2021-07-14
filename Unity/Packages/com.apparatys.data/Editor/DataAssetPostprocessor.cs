using UnityEditor;
using UnityEngine;

namespace Apparatys.DataEditor
{
    public class DataAssetPostprocessor : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            foreach (string str in importedAssets)
            {
                IDataWrapper wrapper = AssetDatabase.LoadAssetAtPath<ScriptableObject>(str) as IDataWrapper;
                if (wrapper != null)
                {
                    wrapper.Initialize();
                }
            }
        }
    }
}
