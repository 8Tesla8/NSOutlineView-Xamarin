using System;
using System.Collections.Generic;
using Foundation;

namespace OutlineViewWithCheckbox {

    public enum State {
        On,
        Off,
        Mixed,
    }


    public class Node : NSObject {
    
        public string Name { get; set; }
        public State State { get; set; } 
        public Node Parent { get; }

		public List<Node> Children { get; private set; }
        
		public bool HasChildren => Children.Count > 0;
        
		public Node(Node parent) {
            Parent = parent;

			Name = string.Empty;
            State = State.Off;
            Children = new List<Node>();
		}
       

        public void SetStateToChildren(State state) {
            State = state;

            if (HasChildren) {
                foreach (var child in Children)
                    child.SetStateToChildren(state);
            }
        }


        public void SetStateToParent(State state) {
            if (Parent != null) {
                var countChildOnState = 0;
                var countChildMixedState = 0;

                foreach (var child in Parent.Children) {
                    if (child.State == State.On)
                        ++countChildOnState;
                    else if (child.State == State.Mixed)
                        ++countChildMixedState;
                }

                if (countChildOnState == Parent.Children.Count)
                    Parent.State = State.On;
                else if (countChildOnState > 0 ||
                        countChildMixedState > 0)
                    Parent.State = State.Mixed;
                else
                    Parent.State = State.Off;

                Parent.SetStateToParent(state);
            }
        }
    }
}

