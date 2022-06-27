using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class DialogueModel
    {
        public Dialogue[] Dialogues;
    }

    [Serializable]
    public class Card
    {
        public int id;
        public int queststep_id;
        public Image image;
        public DateTime updated_at;
    }

    [Serializable]
    public class Image
    {
        public string file_id;
    }

    [Serializable]
    public class Dialogue
    {
        public string description;
        public string choice_description;
        public int id;
        public List<Visualisation> visualisations;
        public Card card;
    }

    [Serializable]
    public class Visualisation
    {
        public string title;
        public string description;
        public int id;
    }

}