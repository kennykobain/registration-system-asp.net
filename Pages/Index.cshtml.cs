using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Styles = new List<string>();
        Styles.Add("/css/tailwind.css");
    }
    
    public List<string> Styles { get; set;}

    [BindProperty]
    public string Number1 { get; set; }
    [BindProperty]
    public string Number2 { get; set; }
    [BindProperty]
    public string Number3 { get; set; }

    public int Count { get; set; }
    public double MaxNumber { get; set; }
    public double MinNumber { get; set; }
    public double Total { get; set; }
    public double Average { get; set; }
    public bool ShowResult { get; set; }
    public bool ErrorMsg { get; set; }
    
    public void OnPost()
    {
        double total = 0;
        int count = 0;
        
        if(double.TryParse(Number1, out double num1))
        {
            total += num1;
            count++;
        }
        if(double.TryParse(Number2, out double num2))
        {
            total += num2;
            count++;
        }

        if (double.TryParse(Number3, out double num3))
        {
            total += num3;
            count++;
        }
        if(count > 0)
        {
            MaxNumber = (double)Math.Max(Math.Max(num1, num2), num3);
            MinNumber = (double)Math.Min(Math.Min(num1, num2), num3);
            Total = total;
            Count = count;
            Average = Total / count;
            ShowResult = true;
            ErrorMsg = false;
        }
        else
        {
            ShowResult = false;
            ErrorMsg = true;
        }
    }
}