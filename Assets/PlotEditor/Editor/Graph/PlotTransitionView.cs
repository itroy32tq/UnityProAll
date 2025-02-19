using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace PlotEditor
{
    public sealed class PlotTransitionView : VisualElement
    {
        public event Action<PlotTransitionView> OnDelete;

        private TextField _text;
        private Port _port;

        public PlotTransitionView(string answer)
        {
            CreateButtonDelete();
            CreateTextAnswer(answer);
            CreatePortOutput();
            style.flexDirection = FlexDirection.Row;
        }

        private void CreateButtonDelete()
        {
            Button button = new()
            {
                text = "X",
                clickable = new Clickable(OnDeleteClicked)
            };

            button.AddToClassList("dialogue-node-remove-choice-button");

            Add(button);
        }

        private void CreateTextAnswer(string answer)
        {
            _text = new TextField
            {
                value = answer,
                multiline = false,
                style =
                {
                    width = 128
                }
            };

            Add(_text);
        }

        public Port GetPort()
        {
            return _port;
        }

        public bool IsPort(Port port)
        {
            return _port == port;
        }

        private void CreatePortOutput()
        {
            _port = Port.Create<PlotEdgeView>(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, null);
            _port.portColor = Color.yellow;
            Add(_port);
        }

        private void OnDeleteClicked()
        {
            OnDelete?.Invoke(this);
        }

        public string GetText()
        {
            return _text.value;
        }
    }
}