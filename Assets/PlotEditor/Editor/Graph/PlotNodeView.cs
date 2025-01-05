using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace PlotEditor
{
    public sealed class PlotNodeView : Node
    {
        private readonly string _id;

        private readonly List<PlotTransitionView> _transitions = new();
        
        private TextField _textMessage;
        private Port _inputPort;
        private bool _isRoot;
        
        public PlotNodeView(string id)
        {
            _id = id;

            title = "Plot Node";
            
            CreateTextMessage();

            CreatePortInput();

            CreateButtonAddDoTransition();

            ApplyStyles();

            RefreshExpandedState();
        }
        
        public string GetId()
        {
            return _id;
        }

        public string GetMessage()
        {
            return _textMessage.value;
        }

        public void SetMessage(string message)
        {
            _textMessage.value = message;
        }

        public PlotTransitionView[] GetTransitions()
        {
            return _transitions.ToArray();
        }
        
        public void CreateTransition(string answer)
        {
            PlotTransitionView transition = new(answer);

            transition.OnDelete += DeleteTransition;

            _transitions.Add(transition);

            outputContainer.Add(transition);

            RefreshExpandedState();
        }

        public void DeleteTransition(PlotTransitionView transition)
        {
            transition.OnDelete -= DeleteTransition;
            _transitions.Remove(transition);
            outputContainer.Remove(transition);
            RefreshExpandedState();
        }

        private void ApplyStyles()
        {
            mainContainer.AddToClassList("dialogue_node_main-container");
        }

        private void CreateButtonAddDoTransition()
        {
            Button button = new()
            {
                text = "Add Transition",
                clickable = new Clickable(OnCreateTransitionClicked)
            };
            
            button.AddToClassList("dialogue-node-add-choice-button");

            mainContainer.Add(button);
        }

        private void OnCreateTransitionClicked()
        {
           CreateTransition("Enter id for plot entry...");
        }
        
       
        private void CreatePortInput()
        {
            _inputPort = Port.Create<PlotEdgeView>(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, null);
            _inputPort.portName = "Input";
            inputContainer.Add(_inputPort);
        }

        private void CreateTextMessage()
        {
            _textMessage = new TextField
            {
                value = "Enter Message",
                multiline = true
            };
            
            _textMessage.AddToClassList("dialogue-node-text-message");

            extensionContainer.Add(_textMessage);
        }

        public int IndexOfOutputPort(Port port)
        {
            for (var i = 0; i < _transitions.Count; i++)
            {
                var choice = _transitions[i];
                if (choice.IsPort(port))
                {
                    return i;
                }
            }

            throw new Exception("Index of port is not found!");
        }

        public Port GetOutputPort(int index)
        {
            return _transitions[index].GetPort();
        }

        public Port GetInputPort()
        {
            return _inputPort;
        }

        public void SetRoot(bool isRoot)
        {
            _isRoot = isRoot;
            style.backgroundColor = isRoot 
                ? new Color(0.92f, 0.76f, 0f) 
                : new Color(0.53f, 0.53f, 0.56f);
        }

        public bool IsRoot()
        {
            return _isRoot;
        }
    }
}