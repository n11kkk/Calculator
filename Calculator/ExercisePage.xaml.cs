using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Calculator;

public partial class ExercisePage : ContentPage
{
    HttpClient _client;
    JsonSerializerOptions _serializerOptions;
    public ExercisePage()
    {
        InitializeComponent();
        _client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    private readonly string ExerciseApi = "https://localhost:7161/Exercise";
    public class Exercise
    {
        public int[]? FirstNum { get; set; }
        public int[]? SecondNum { get; set; }

        public string[]? Operators { get; set; }
        public int[]? Answers { get; set; }

        public int[][]? Options { get; set; }

    }
    public static class Global
    {
        public static Exercise fullResponse = new Exercise{ };

        public static int questionNumber = 0;
    }
    async Task<Exercise> GetExercise()
    {

        try
        {

            var response = await _client.GetAsync(ExerciseApi);
            string respString = await response.Content.ReadAsStringAsync();
            var finalResp = JsonSerializer.Deserialize<Exercise>(respString, _serializerOptions);

            System.Diagnostics.Debug.WriteLine(finalResp);
            return finalResp;
        }
        catch (HttpRequestException h)
        {
            System.Diagnostics.Debug.WriteLine(h);
        }

        return null;

    }


    async void OnClickedNewExercise(object sender, EventArgs e)
    {
        var response = await GetExercise();
        Global.questionNumber = 0;
        if (response != null)
        {
            Global.fullResponse = response;
            System.Diagnostics.Debug.WriteLine(response.FirstNum[Global.questionNumber]);
            FirstNumber.Text = $"{response.FirstNum[Global.questionNumber]}";
            Operator.Text = $"{response.Operators[Global.questionNumber]}";
            SecondNumber.Text = $"{response.SecondNum[Global.questionNumber]}";
            Option1.Text = $"{response.Options[Global.questionNumber][0]}";
            Option2.Text = $"{response.Options[Global.questionNumber][1]}";
            Option3.Text = $"{response.Options[Global.questionNumber][2]}";
        }
        //System.Diagnostics.Debug.WriteLine(response);
    }

}