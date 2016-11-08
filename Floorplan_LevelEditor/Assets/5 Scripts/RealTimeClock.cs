using UnityEngine;
using System.Collections;
using System;

public class RealTimeClock {

    DateTime currentTime;

    public DateTime? recordedTime = null;

    public bool timeSinceLoadBool = false;
   //DateTime areaCreationTime;
   //DateTime? areaLoadedTime = null;


    public void RegisterSaveTime() {
        timeSinceLoadBool = false;
        recordedTime = DateTime.Now;
    }

    public void RegisterLoadTime() {
        timeSinceLoadBool = true;
        recordedTime = DateTime.Now;
    }

    public void ResetForCreation() {
        recordedTime = null;
        timeSinceLoadBool = false;
    }


    public string TimeSinceLastSave() {
        currentTime = DateTime.Now;
        TimeSpan timeSinceLastSave = currentTime - (DateTime)recordedTime;      // a null check is included in caller Method - AreaSaveLoadUI.RefreshLastSaveTime()  (TimeSpan isn't nullable)

        return "<b>" + timeSinceLastSave.Hours + ":" + timeSinceLastSave.Minutes + ":" + timeSinceLastSave.Seconds + "</b>  ago";
    }

    public string TimeSinceLoad() {
        currentTime = DateTime.Now;
        TimeSpan timeSinceLastSave = currentTime - (DateTime)recordedTime;      // a null check is included in caller Method - AreaSaveLoadUI.RefreshLastSaveTime()  (TimeSpan isn't nullable)

        return "Load: <b>" + timeSinceLastSave.Hours + ":" + timeSinceLastSave.Minutes + ":" + timeSinceLastSave.Seconds + "</b>  ago";
    }


/*
    public DateTime GetCurrentTime() {
        currentTime = DateTime.Now;

        return currentTime;
    }


    public string TimeSinceAreaCreation() {
        currentTime = DateTime.Now;
        TimeSpan timeSinceCreation = currentTime - areaCreationTime;

        return timeSinceCreation.Hours + ":" + timeSinceCreation.Minutes + ":" + timeSinceCreation.Seconds + "  ago";
    }


    public string TimeSinceAreaLoaded() {
        currentTime = DateTime.Now;
        TimeSpan TimeSinceAreaLoaded = currentTime - (DateTime)areaLoadedTime;

        return TimeSinceAreaLoaded.Hours + ":" + TimeSinceAreaLoaded.Minutes + ":" + TimeSinceAreaLoaded.Seconds + "  ago";
    }
*/

}
