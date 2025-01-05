using System;
using UnityEngine;

namespace PlotEditor
{
    [CreateAssetMenu(
        fileName = "DialogueConfig",
        menuName = "Dialogues/New DialogueConfig"
    )]
    public sealed class PlotEditorConfig : ScriptableObject
    {
        public string rootId;
        
        public Node[] Nodes;
        public Edge[] Edges;
        
        [Serializable]
        public struct Node
        {
            public string Id;
            public string Text;
            public string[] Transitions;
            public Vector2 EditorPosition;
        }
        
        [Serializable]
        public struct Edge
        {
            public string inputNodeId;
            public string outputNodeId;
            public int outputIndex;
        }
        
        public bool FindRootNode(out Node node)
        {
            return FindNode(rootId, out node);
        }

        private bool FindNode(string id, out Node result)
        {
            for (int i = 0, count = Nodes.Length; i < count; i++)
            {
                Node node = Nodes[i];

                if (node.Id == id)
                {
                    result = node;
                    return true;
                }
            }

            result = default;
            return false;
        }

        public bool FindNextNode(string currentNodeId, int choiceIndex, out Node nextNode)
        {
            for (int i = 0, count = Edges.Length; i < count; i++)
            {
                Edge edge = Edges[i];
                
                if (edge.outputNodeId == currentNodeId && edge.outputIndex == choiceIndex)
                {
                    if (FindNode(edge.inputNodeId, out nextNode))
                    {
                        return true;
                    }
        
                    return false;
                }
            }

            nextNode = default;
            return false;
        }
    }
}