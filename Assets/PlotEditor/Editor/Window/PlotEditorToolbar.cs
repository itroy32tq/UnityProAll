using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace PlotEditor
{
    public sealed class PlotEditorToolbar : Toolbar
    {
        internal PlotEditorToolbar(PlotEditorGraphView graphView)
        {
            ObjectField configField = CreateConfigField();

            Button loadButton = CreateButtonLoad(graphView, configField);
            Button saveButton = CreateButtonSave(graphView, configField);
            Button resetButton = CreateButtonReset(graphView, configField);

            Add(configField);
            Add(loadButton);
            Add(saveButton);
            Add(resetButton);
        }

        private static ObjectField CreateConfigField()
        {
            return new ObjectField("Selected tree")
            {
                objectType = typeof(PlotEditorConfig),
                allowSceneObjects = false
            };
        }

        private static Button CreateButtonSave(PlotEditorGraphView graphView, ObjectField configField)
        {
            return new Button
            {
                text = "Save Config",
                clickable = new Clickable(() =>
                {
                    PlotEditorConfig config = configField.value as PlotEditorConfig;
                    
                    if (config != null)
                    {
                        PlotTreeSaver.SavePlotTree(graphView, config);
                    }
                    else
                    {
                        PlotTreeSaver.SaveDialogAsNew(graphView, out config);
                        configField.value = config;
                    }
                })
            };
        }

        private static Button CreateButtonLoad(PlotEditorGraphView graphView, ObjectField configField)
        {
            return new Button
            {
                text = "Load Config",
                clickable = new Clickable(() =>
                {
                    PlotTreeLoader.LoadDialog(configField.value as PlotEditorConfig, graphView);
                })
            };
        }

        private static Button CreateButtonReset(PlotEditorGraphView graphView, ObjectField configField)
        {
            return new Button
            {
                text = "Reset Dialog",
                clickable = new Clickable(() =>
                {
                    graphView.ResetState();
                    configField.value = null;
                })
            };
        }
    }
}