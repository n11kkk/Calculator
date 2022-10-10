namespace Calculator;

public partial class ComplexMathPage : ContentPage
{
	public ComplexMathPage()
	{
		InitializeComponent();
        OnClear(this, null);
    }
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
    void OnSqrt(object sender, EventArgs e)
    {


        if (currentEntry1.Length > 0)
        {
            if (currentEntry1[currentEntry1.Length - 1] != '+' || currentEntry1[currentEntry1.Length - 1] != '-' || currentEntry1[currentEntry1.Length - 1] != '*' || currentEntry1[currentEntry1.Length - 1] != '/')
            {
                var currentEntryTemp = $"{currentEntry1}";
                currentEntry1 = $"sqrt({currentEntry1})";
                this.resultText1.Text = $"√{currentEntryTemp}";

            }
        }

    }

    void onMod(object sender, EventArgs e)
    {

        if (currentEntry1.Length > 0)
        {
            if (currentEntry1[currentEntry1.Length - 1] != '+' || currentEntry1[currentEntry1.Length - 1] != '-' || currentEntry1[currentEntry1.Length - 1] != '*' || currentEntry1[currentEntry1.Length - 1] != '/')
            {
                currentEntry1 += "%25";
                this.resultText1.Text += "%";

            }
        }
    }
}