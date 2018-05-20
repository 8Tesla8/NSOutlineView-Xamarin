using System;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace OutlineViewWithCheckbox {
    public class DataSource : NSOutlineViewDataSource {
		
		public DataSource(List<Node> data) {
			if (data == null)
				Data = new List<Node>();
			else
				Data = data;
		}

		public List<Node> Data { get; private set; }


        public override nint GetChildrenCount(NSOutlineView outlineView, NSObject item) {
            if (item == null)
                return Data.Count;

            return ((Node)item).Children.Count;
        }


        public override NSObject GetChild(NSOutlineView outlineView, nint childIndex, NSObject item) {
            if (item == null)
                return Data[(int)childIndex];

            return ((Node)item).Children[(int)childIndex];
        }


        public override bool ItemExpandable(NSOutlineView outlineView, NSObject item) {
            if (item == null)
                return Data[0].HasChildren;

            return ((Node)item).HasChildren;
        }
    }
}

