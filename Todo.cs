using System;
using System.Text.Json.Serialization;
using Azure;
using Azure.Data.Tables;

namespace TodoApiAzureFunctions;

/// <summary>
/// Represents a Todo item
/// </summary>
public class Todo : ITableEntity
{
    [JsonIgnore]
    string ITableEntity.PartitionKey { get; set; } = "Http";

    [JsonIgnore] 
    string ITableEntity.RowKey { get; set; }

    [JsonIgnore]
    ETag ITableEntity.ETag { get; set; }

    [JsonIgnore]
    DateTimeOffset? ITableEntity.Timestamp { get; set; }

    /// <summary>
    /// Id of the todo
    /// </summary>
    public string Id
    {
        get => ((ITableEntity) this).RowKey;
        set => ((ITableEntity)this).RowKey = value;
    }

    /// <summary>
    /// Position of the todo in the list
    /// </summary>
    public int? Order { get; set; }
    /// <summary>
    /// Title of the todo. Explains what the task is about.
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// Reference to the url that can be used to get the details of the item.
    /// </summary>
    public string? Url { get; set; }
    /// <summary>
    /// Indicates whether the task is complete or not.
    /// </summary>
    public bool Completed { get; set; }
}