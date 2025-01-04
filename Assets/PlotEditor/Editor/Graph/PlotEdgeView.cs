using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;

namespace PlotEditor
{
    public sealed class PlotEdgeView : Edge
    {
        [UsedImplicitly]
        public PlotEdgeView()
        {
        }
        
        public string GetInputId()
        {
            return ((PlotNodeView) input.node).GetId();
        }

        public string GetOutputId()
        {
            return ((PlotNodeView) output.node).GetId();
        }

        public int GetOutputIndex()
        {
            return ((PlotNodeView) output.node).IndexOfOutputPort(output);
        }
    }
}