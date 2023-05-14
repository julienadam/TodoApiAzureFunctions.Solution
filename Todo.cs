using System.Text.Json.Serialization;

namespace TodoApiAzureFunctions;

/// <summary>
/// Represents a Todo item
/// </summary>
public record Todo
{
    [JsonIgnore]
    public string PartitionKey { get; } = "Http";

    [JsonIgnore] public string RowKey => Id;

    /// <summary>
    /// Id of the todo
    /// </summary>
    public string Id { get; set; }
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