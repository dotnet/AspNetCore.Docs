using System;
using System.Web;
using System.Web.UI;

public static class PageExtensionMethods
{
	public static Control FindControlRecursive(this Control ctrl, string controlID)
	{
		if (string.Compare(ctrl.ID, controlID, true) == 0)
		{
			// We found the control!
			return ctrl;
		}
		else
		{
			// Recurse through ctrl's Controls collections
			foreach (Control child in ctrl.Controls)
			{
				Control lookFor = FindControlRecursive(child, controlID);

				if (lookFor != null)
					return lookFor;  // We found the control
			}

			// If we reach here, control was not found
			return null;
		}
	}
}