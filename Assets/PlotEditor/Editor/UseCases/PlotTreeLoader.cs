using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlotEditor
{
    public static class PlotTreeLoader
    {
        public static void LoadDialog(PlotEditorConfig config, PlotEditorGraphView graphView)
        {
            graphView.ResetState();

            if (config == null)
            {
                Debug.LogWarning("Config is null!");

                return;
            }

            List<PlotNodeView> nodeViews = new();
            
            foreach (PlotEditorConfig.Node node in config.nodes)
            {
                PlotNodeView nodeView = graphView.CreateNode(node.Id, node.EditorPosition);

                nodeView.SetMessage(node.Text);

                foreach (string trans in node.Transitions)
                {
                    nodeView.CreateTransition(trans);
                }

                nodeViews.Add(nodeView);
            }

            foreach (PlotEditorConfig.Edge edge in config.edges)
            {
                string outputId = edge.outputNodeId;
                PlotNodeView outputNode = nodeViews.First(it => it.GetId() == outputId);

                string inputId = edge.inputNodeId;
                PlotNodeView inputNode = nodeViews.First(it => it.GetId() == inputId);

                int outputIndex = edge.outputIndex;

                graphView.CreateEdge(outputNode, outputIndex, inputNode);
            }

            graphView.SetRootNode(config.rootId);
        }
    }
}