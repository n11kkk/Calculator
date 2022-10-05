using Calculator.Themes;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Web;

namespace Calculator;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        OnClear(this, null);

    }



    /* public static async Task<object> Calc()
     {

         var client = new HttpClient();
         var info = new Object();
         string expr = "{\"expr\":3+10-5}";
         StringContent exprrr = new StringContent(expr,Encoding.UTF8,"application/json");
         string url = "http://api.mathjs.org/v4/";
         client.BaseAddress = new Uri(url);
         var response = await client.PostAsync(client.BaseAddress, exprrr);
         if (response.IsSuccessStatusCode)
         {
             string content = response.Content.ReadAsStringAsync().Result;

             info = JsonConvert.DeserializeObject(content);



             return info;

         }
         else
         {
             return null;
         }

     }



     public class Express
     {
         public string Result { get; set; }
         public string Error { get; set; }
     }*/


    async Task<string> Docal()
    {
        var client = new HttpClient();

        string plusChanged = currentEntry1.Replace("+", "%2B");

        System.Diagnostics.Debug.WriteLine($"{plusChanged}");

        string httpApi = $"http://api.mathjs.org/v4/?expr={plusChanged}";

        System.Diagnostics.Debug.WriteLine($"tHIS IS PLUS{httpApi}");

        var response = await client.GetAsync(httpApi);

        var responseString = await response.Content.ReadAsStringAsync();



        if (responseString.StartsWith("Error"))
        {
            System.Diagnostics.Debug.WriteLine("There is an error");
            return "Err";
        }
        else
        {
            System.Diagnostics.Debug.WriteLine(responseString);
            this.currentCalculation1.Text = responseString;
            return responseString.ToString();
        }


    }


    /* public async Task<string> Calcc()

     {
         var client = new HttpClient();
         var values = new Dictionary<string, string>
         {
              { "expr", "9+18-6" },
         };

         var content = new FormUrlEncodedContent(values);

         var response = await client.PostAsync("http://api.mathjs.org/v4/", content);

         var responseString = await response.Content.ReadAsStringAsync();

         if (responseString != "Error")
         {
             return "responseString";
         }
         else
         {
             return "error";
         }

     }*/


    void OnHit(object sender, EventArgs e)
    {

        Docal().ToString();


    }

    public void OnSelected1(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressed = button.Text;


        if (currentEntry1.Length < 1)
        {
            if (pressed != "+" && pressed != "*" && pressed != "/")
            {
                currentEntry1 = pressed;
                this.resultText1.Text = pressed;
            }
        }

        else
        {
            System.Diagnostics.Debug.WriteLine($"This is the Last{currentEntry1[currentEntry1.Length - 1]}");

            if (currentEntry1[currentEntry1.Length - 1] == '+' || currentEntry1[currentEntry1.Length - 1] == '-' || currentEntry1[currentEntry1.Length - 1] == '*' || currentEntry1[currentEntry1.Length - 1] == '/')
            {
                if (pressed != "+" && pressed != "-" && pressed != "*" && pressed != "/")
                {
                    currentEntry1 += pressed;
                    this.resultText1.Text += pressed;
                }

            }
            else
            {
                currentEntry1 += pressed;
                this.resultText1.Text += pressed;
            }

        }

        System.Diagnostics.Debug.WriteLine("Later");
        System.Diagnostics.Debug.WriteLine(currentEntry1);
        System.Diagnostics.Debug.WriteLine(this.resultText1.Text);

    }




    string currentEntry1 = "";


    void OnDark(object sender, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();

            mergedDictionaries.Add(new DarkTheme());

        }
    }

    void OnLight(object sender, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();

            mergedDictionaries.Add(new LightTheme());

        }
    }




    void OnClear(object sender, EventArgs e)
    {


        this.resultText1.Text = "0";

        currentEntry1 = string.Empty;
    }


    void OnPercentage(object sender, EventArgs e)
    {


            if (currentEntry1.Length > 0)
            {
                if (currentEntry1[currentEntry1.Length - 1] != '+' || currentEntry1[currentEntry1.Length - 1] != '-' || currentEntry1[currentEntry1.Length - 1] != '*' || currentEntry1[currentEntry1.Length - 1] != '/')
                {
                    currentEntry1 += "*0.01";
                    this.resultText1.Text += "*0.01";

                }
            }

    }
}
