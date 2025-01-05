using UnityEditor;
using UnityEngine.UIElements;

namespace PlotEditor
{
    public static class AssetsHelper
    {
        public static StyleSheet LoadNodeStyleSheet()
        {
            return AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/PlotEditor/Styles/PlotEditorNode.uss");
        }
        
        public static StyleSheet LoadGridStyleSheet()
        {
            return AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/PlotEditor/Styles/PlotEditorGrid.uss");
        }
    }
}