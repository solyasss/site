namespace _03._03hw.Models;

public class ErrorViewModel
{
    public string request_id { get; set; }
    public bool show_request_id => !string.IsNullOrEmpty(request_id);
}