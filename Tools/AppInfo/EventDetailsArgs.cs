using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppInfo
{
   public class EventDetailsArgs : EventArgs
   {
      public EventDetails EventDetails { get; private set; }
      public EventArgs EventArgs { get; private set; }

      public EventDetailsArgs(EventDetails ed, EventArgs ea)
      {
         EventDetails = ed;
         EventArgs = ea;
      }
   }
}
