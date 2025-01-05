using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace PlotEditor
{
    public sealed class PlotEditorGraphView : GraphView
    {
        public PlotEditorGraphView()
        {
            CreateBackground();

            CreateManipulators();

            ApplyStyles();
        }

        public PlotNodeView[] GetNodes()
        {
            List<PlotNodeView> viewNodes = new();

            foreach (Node node in nodes)
            {
                viewNodes.Add((PlotNodeView) node);
            }
            
            return viewNodes.ToArray();
        }

        public PlotEdgeView[] GetEdges()
        {
            List<Edge> edges = this.edges.ToList();
            PlotEdgeView[] result = new PlotEdgeView[edges.Count];

            for (int i = 0; i < edges.Count; i++)
            {
                result[i] = (PlotEdgeView) edges[i];
            }

            return result;
        }
        
        public void ResetState()
        {
            foreach (Node node in nodes)
            {
                RemoveElement(node);
            }

            foreach (Edge edge in edges)
            {
                RemoveElement(edge);
            }
        }

        public PlotNodeView CreateNode(string id, Vector2 position)
        {
            PlotNodeView node = new(id);

            node.SetPosition(new Rect(position, Vector2.zero));

            AddElement(node);

            return node;
        }

        public void CreateEdge(PlotNodeView outputNode, int outputIndex, PlotNodeView inputNode)
        {
            Port outputPort = outputNode.GetOutputPort(outputIndex);
            Port inputPort = inputNode.GetInputPort();

            PlotEdgeView edge = new()
            {
                input = inputPort,
                output = outputPort
            };

            AddElement(edge);
        }

        private void CreateManipulators()
        {
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new ContentZoomer());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
            this.AddManipulator(new ContextualMenuManipulator(OnContextMenuClicked));
        }
        
        private void CreateBackground()
        {
            GridBackground gridBackground = new();

            gridBackground.StretchToParentSize();

            Insert(0, gridBackground);
        }

        private void ApplyStyles()
        {
            styleSheets.Add(AssetsHelper.LoadNodeStyleSheet());
            styleSheets.Add(AssetsHelper.LoadGridStyleSheet());
        }

        private void OnContextMenuClicked(ContextualMenuPopulateEvent menuEvent)
        { 
            menuEvent.menu.AppendAction("Create Node", OnCreateNode);
            
            if (menuEvent.target is PlotNodeView selectedNode)
            {
                menuEvent.menu.AppendAction("Set As Root", _ => SetRootNode(selectedNode));
            }
        }

        private void OnCreateNode(DropdownMenuAction menuAction)
        {
            Vector2 mousePosition = menuAction.eventInfo.localMousePosition;
            Vector2 worldPosition = this.ChangeCoordinatesTo(parent, mousePosition);
            Vector2 fixedLocalPosition = contentViewContainer.WorldToLocal(worldPosition);
            
            string nodeId = Guid.NewGuid().ToString();

            PlotNodeView nodeView = CreateNode(nodeId, fixedLocalPosition);

            List<Node> nodes = this.nodes.ToList();
            nodeView.SetRoot(nodes.Count == 1);
        }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            List<Port> result = new();
            
            foreach (Port port in ports)
            {
                if (port == startPort)
                {
                    continue;
                }

                if (port.node == startPort.node)
                {
                    continue;
                }

                if (port.direction == startPort.direction)
                {
                    continue;
                }
                
                result.Add(port);
            }

            return result;
        }
        
        public void SetRootNode(string rootNodeId)
        {
            foreach (Node node in this.nodes)
            {
                PlotNodeView dialogueNode = (PlotNodeView) node;
                dialogueNode.SetRoot(dialogueNode.GetId() == rootNodeId);
            }
        }
        
        public void SetRootNode(PlotNodeView nodeView)
        {
            foreach (Node node in this.nodes)
            {
                PlotNodeView dialogueNode = (PlotNodeView) node;
                dialogueNode.SetRoot(dialogueNode == nodeView);
            }
        }

        public bool TryGetRootNode(out PlotNodeView result)
        {
            foreach (var node in this.nodes)
            {
                result = (PlotNodeView) node;
                if (result.IsRoot())
                {
                    return true;
                }
            }

            result = default;
            return false;
        }
    }
}
