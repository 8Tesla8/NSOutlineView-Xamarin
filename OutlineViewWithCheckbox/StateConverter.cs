using System;
using AppKit;

namespace OutlineViewWithCheckbox {
    public static class StateConverter {
        
		public static State ConvertCheckboxState(NSButton checkbox) {
            switch (checkbox.State) {
                case NSCellStateValue.On:
                    return State.On;

                case NSCellStateValue.Off:
                    return State.Off;

                default:
                    return State.Mixed;
            }
        }


        public static NSCellStateValue ConvertNodeState(Node node) {
            switch (node.State) {
                case State.On:
                    return NSCellStateValue.On;

                case State.Off:
                    return NSCellStateValue.Off;

                default:
                    return NSCellStateValue.Mixed;
            }
        }

    }
}
