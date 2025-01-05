using UnityEditor;
using UnityEngine.UIElements;

namespace PlotEditor
{
    public sealed class PlotEditorWindow : EditorWindow
    {
        private PlotEditorGraphView _graphView;
        
         private void CreateGUI()
         {
             CreateGraph();
             CreateToolbar();
         }

         private void CreateGraph()
         {
             _graphView = new PlotEditorGraphView();
             _graphView.StretchToParentSize();
             rootVisualElement.Insert(0, _graphView);
         }
         
         private void CreateToolbar()
         {
            PlotEditorToolbar toolbar = new(_graphView);

            rootVisualElement.Add(toolbar);
         }
    }
}


