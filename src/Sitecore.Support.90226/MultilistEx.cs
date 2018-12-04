namespace Sitecore.Support.Shell.Applications.ContentEditor
{
  using Sitecore;
  using Sitecore.Data.Items;
  using Sitecore.Diagnostics;
  using Sitecore.Globalization;
  using Sitecore.Resources;
  using Sitecore.Shell.Applications.ContentEditor;
  using Sitecore.Text;
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web.UI;
  public class MultilistEx : Sitecore.Shell.Applications.ContentEditor.MultilistEx
  {
    protected override void GetSelectedItems(Item[] sources, out System.Collections.ArrayList selected, out System.Collections.IDictionary unselected)
    {
      Assert.ArgumentNotNull(sources, "sources");
      ListString str = new ListString(base.Value);
      unselected = new System.Collections.SortedList();
      List<Item> unselectedList = new List<Item>();
      selected = new System.Collections.ArrayList(str.Count);
      for (int i = 0; i < str.Count; i = (int)(i + 1))
      {
        selected.Add(str[i]);
      }
      foreach (Item item in sources)
      {
        string str2 = item.ID.ToString();
        int index = str.IndexOf(str2);
        if (index >= 0)
        {
          selected[index] = item;
        }
        else
        {
          unselectedList.Add(item);
        }
      }
      unselected = unselectedList.ToDictionary(x => x);
    }
  }
}
