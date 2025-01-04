using UnityEditor;

namespace PlotEditor
{
    public sealed class PlotEditorMenu
    {
        [MenuItem("Window/PlotEditor")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<PlotEditorWindow>("PlotEditor");
        }
    }
}