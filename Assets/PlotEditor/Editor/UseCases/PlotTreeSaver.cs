using UnityEditor;
using UnityEngine;

namespace PlotEditor
{
    public static class PlotTreeSaver
    {
        public static void SaveDialogAsNew(PlotEditorGraphView graph, out PlotEditorConfig config)
        {
            string path = EditorUtility.SaveFilePanelInProject("Save file", "PlotTree", "asset", "");

            config = ScriptableObject.CreateInstance<PlotEditorConfig>();
            AssetDatabase.CreateAsset(config, path);

            SavePlotTree(graph, config);
        }
        
        public static void SavePlotTree(PlotEditorGraphView graphView, PlotEditorConfig config)
        {
            config.Nodes = ConvertNodes(graphView);
            config.Edges = ConvertEdges(graphView);
            
            if (graphView.TryGetRootNode(out PlotNodeView rootNode))
            {
                config.rootId = rootNode.GetId();
            }

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        private static PlotEditorConfig.Node[] ConvertNodes(PlotEditorGraphView graphView)
        {
            PlotNodeView[] nodeViews = graphView.GetNodes();
            int count = nodeViews.Length;

            PlotEditorConfig.Node[] nodes = new PlotEditorConfig.Node[count];

            for (int i = 0; i < count; i++)
            {
                PlotNodeView nodeView = nodeViews[i];

                PlotEditorConfig.Node node = new()
                {
                    Id = nodeView.GetId(),
                    Text = nodeView.GetMessage(),
                    EditorPosition = nodeView.GetPosition().position,
                    Transitions = ConvertTransitions(nodeView)
                };

                nodes[i] = node;
            }

            return nodes;
        }

        private static string[] ConvertTransitions(PlotNodeView nodeView)
        {
            PlotTransitionView[] transitionsViews = nodeView.GetTransitions();

            int count = transitionsViews.Length;

            string[] transitions = new string[count];

            for (int i = 0; i < count; i++)
            {
                PlotTransitionView transitionView = transitionsViews[i];
                string transitionText = transitionView.GetText();
                transitions[i] = transitionText;
            }

            return transitions;
        }

        private static PlotEditorConfig.Edge[] ConvertEdges(PlotEditorGraphView graphView)
        {
            PlotEdgeView[] edgeViews = graphView.GetEdges();
            int count = edgeViews.Length;

            PlotEditorConfig.Edge[] edges = new PlotEditorConfig.Edge[count];

            for (int i = 0; i < count; i++)
            {
                PlotEdgeView edgeView = edgeViews[i];
                PlotEditorConfig.Edge edge = new PlotEditorConfig.Edge
                {
                    inputNodeId = edgeView.GetInputId(),
                    outputNodeId = edgeView.GetOutputId(),
                    outputIndex = edgeView.GetOutputIndex()
                };

                edges[i] = edge;
            }

            return edges;
        }
    }
}