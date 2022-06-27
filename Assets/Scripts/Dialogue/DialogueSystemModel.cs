using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class DialogueSystemModel
    {
        public DialogueSystem[] DialoguesSystem;
    }

    [Serializable]
    public class DialogueSystem
    {
        public int source_id;
        public int target_id;
        public object id;
    }
}