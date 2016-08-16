using UnityEngine;
using System.Collections;
using System;

public class TimeSinceSave {

    DateTime currentTime;

    public DateTime? areaLastSaveTime = null;
   //DateTime areaCreationTime;
   //DateTime? areaLoadedTime = null;


    public void RegisterSaveTime() {
        areaLastSaveTime = DateTime.Now;
    }
/*
    public void RegisterCreationTime() {
        areaCreationTime = DateTime.Now;
    }*/
/*
    public void RegisterLoadTime() {
        areaLoadedTime = DateTime.Now;
    }
*/

    public string TimeSinceLastSave() {
        currentTime = DateTime.Now;
        TimeSpan timeSinceLastSave = currentTime - (DateTime)areaLastSaveTime;      // a null check is included in caller Method - AreaSaveLoadUI.RefreshLastSaveTime()  (TimeSpan isn't nullable)

        return "<b>" + timeSinceLastSave.Hours + ":" + timeSinceLastSave.Minutes + ":" + timeSinceLastSave.Seconds + "</b>  ago";
    }
/*
    public string TimeSinceAreaCreation() {
        currentTime = DateTime.Now;
        TimeSpan timeSinceCreation = currentTime - areaCreationTime;

        return timeSinceCreation.Hours + ":" + timeSinceCreation.Minutes + ":" + timeSinceCreation.Seconds + "  ago";
    }
*/
/*
    public string TimeSinceAreaLoaded() {
        currentTime = DateTime.Now;
        TimeSpan TimeSinceAreaLoaded = currentTime - (DateTime)areaLoadedTime;

        return TimeSinceAreaLoaded.Hours + ":" + TimeSinceAreaLoaded.Minutes + ":" + TimeSinceAreaLoaded.Seconds + "  ago";
    }
*/

}
