using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Proyecto26;
using UnityEngine;

public class DBController
{
    public Action<ResponseHelper> OnComplete { get; set; }
    public Action<Exception> OnFailed { get; set; }

    // public static void GetDBCourse(string id)
    // {
    //     if (string.IsNullOrEmpty(id)) return;
    //     var url = GameManager.DATABASE_URL_APP + "/" + id + ".json";
    //     RestClient.Get(url)
    //         .Then(onResolved => HandleSuccess(onResolved))
    //         .Catch(onRejected => HandleError(onRejected));
    // }

    public void PutDBBox(ObjectARData objectARData, string environmentId)
    {
        if (objectARData == null || objectARData.id == "") return;
        var url = GameManager.DATABASE_URL_APP + "/" + environmentId + "/objectsAR/" +objectARData.id + ".json";
        RestClient.Put(url, objectARData)
            .Then(onResolved => HandleSuccess(onResolved))
            .Catch(onRejected => HandleError(onRejected));
    }
    
    // public static void DeleteDBCourse(DBCourse dBCourse)
    // {
    //     if (dBCourse == null || dBCourse.ID == "") return;
    //     DeleteDBScenes(dBCourse);
    //     DeleteDBUsers(dBCourse);
    //     var url = GameManager.DATABASE_URL_APP + "/Courses/" + dBCourse.ID + ".json";
    //     RestClient.Delete(url)
    //         .Then(onResolved => HandleSuccess(onResolved))
    //         .Catch(onRejected => HandleError(onRejected));
    // }

    private void HandleSuccess(ResponseHelper onResolved)
    {
        switch ((HttpStatusCode)onResolved.StatusCode)
        {
            case HttpStatusCode.OK:
                OnComplete?.Invoke(onResolved);
                break;
            default:

                break;
        }
    }
    private void HandleError(Exception onRejected)
    {
        Debug.Log($"Error: Course {onRejected.Message}");
        OnFailed?.Invoke(onRejected);
    }

    public void ResetActions()
    {
        OnComplete = null;
        OnFailed = null;
    }
}
