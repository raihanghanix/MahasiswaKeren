using Godot;
using System;
using System.Collections.Generic;

public partial class DataManager
{
    public class DataClass
    {
        public SceneData scene1 { get; set; }
    }

    public class SceneData
    {
        public int id { get; set; }
        public int week { get; set; }
        public DialogData dialog { get; set; }
        public List<OptionData> options { get; set; }
    }

    public class DialogData
    {
        public List<string> Narator { get; set; }
        public List<string> Player { get; set; }
    }

    public class OptionData
    {
        public int id { get; set; }
        public string text { get; set; }
        public StatsData stats { get; set; }
    }

    public class StatsData
    {
        public int affection { get; set; }
        public int social { get; set; }
        public int academic { get; set; }
        public int economy { get; set; }
    }
}