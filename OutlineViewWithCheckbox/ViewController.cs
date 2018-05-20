using System;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace OutlineViewWithCheckbox {
    public partial class ViewController : NSViewController {
        public ViewController(IntPtr handle) : base(handle) {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.


			var mainNode = new Node(null);
			mainNode.Name = "Root";

			CreateChildren(mainNode, 3);

			for (int i = 0; i < mainNode.Children.Count; i++) {
				var child = mainNode.Children[i];

                CreateChildren(child, 2);

				for (int j = 0; j < child.Children.Count; j++) 
					CreateChildren(child.Children[j], 2);
            }


			var dataSource = new DataSource(
				new List<Node> { mainNode }
			);


			tblT.DataSource = dataSource;
			tblT.Delegate = new TableDelegate();
			//tblT.Delegate = new TableDelegate(dataSource);
		}


		private void CreateChildren(Node node, int count) {
            for (int i = 0; i < count; i++) {
                var child = new Node(node);
                child.Name = node.Name + " " + i;

				node.Children.Add(child);
            }
        }


        public override NSObject RepresentedObject {
            get {
                return base.RepresentedObject;
            }
            set {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
