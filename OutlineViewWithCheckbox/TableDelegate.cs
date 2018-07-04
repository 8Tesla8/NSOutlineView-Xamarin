using System;
using AppKit;
using CoreGraphics;
using Foundation;

namespace OutlineViewWithCheckbox {
    public class TableDelegate : NSOutlineViewDelegate {      

        public override NSView GetView(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item) {
            var node = (Node)item;

            var view = new NSTableCellView();

            //TextField
            view.TextField = new NSTextField(new CGRect(20, 0, 400, 16));
            view.AddSubview(view.TextField);

            view.TextField.BackgroundColor = NSColor.Clear;
            view.TextField.Bordered = false;
            view.TextField.Editable = false;
            view.TextField.Selectable = false;

            view.TextField.StringValue = node.Name;
            view.TextField.ToolTip = node.Name;


            //CheckBox
            var checkBox = new NSButton(new CGRect(5, 0, 16, 16));
            view.AddSubview(checkBox);

            checkBox.SetButtonType(NSButtonType.Switch);
            checkBox.AllowsMixedState = true;

			checkBox.State = StateConverter.ConvertNodeState(node);

            checkBox.Activated += (sender, e) => {
                var ckb = (NSButton)sender;

                if (ckb.State == NSCellStateValue.Mixed)
                    ckb.State = NSCellStateValue.On;

				var state = StateConverter.ConvertCheckboxState(ckb);

                node.SetStateToChildren(state);
                node.SetStateToParent(state);

                outlineView.ReloadData();
            };

            return view;
        }


        public override bool ShouldSelectItem(NSOutlineView outlineView, NSObject item) {
            var animator = outlineView.Animator as NSOutlineView;

            if (outlineView.IsItemExpanded(item))
                animator.CollapseItem(item, false);
            else
                animator.ExpandItem(item, false);

            return false;
        }
    }
}
