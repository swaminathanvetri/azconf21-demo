using System;
using Newtonsoft.Json;

public class TodoModel
{
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; } 
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsDone { get; set; }
}